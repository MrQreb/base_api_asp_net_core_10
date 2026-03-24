using WepAPI.Src.Modules.Users.Dtos;
using WepAPI.Src.Modules.Users.Entities;
using WepAPI.Src.Modules.Users.Repositories;

namespace WepAPI.Src.Modules.Users
{
    /// <summary>
    /// Contiene la lógica de negocio para la gestión de usuarios.
    /// Implementa operaciones CRUD usando el repositorio.
    /// </summary>
    public class UsersService
    {
        private readonly IUserRepository _repo;

        /// <summary>
        /// Inicializa el servicio de usuarios.
        /// </summary>
        /// <param name="repo">Repositorio de usuarios.</param>
        public UsersService(IUserRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Obtiene todos los usuarios activos.
        /// </summary>
        /// <returns>Lista de usuarios.</returns>
        public async Task<List<UserResponseDto>> FindAllAsync()
        {
            var users = await _repo.GetAllAsync();

            return users
                .Select(UserResponseDto.FromEntity)
                .ToList();
        }

        /// <summary>
        /// Obtiene un usuario por su Id.
        /// </summary>
        /// <param name="id">Id del usuario.</param>
        /// <returns>Usuario o null si no existe.</returns>
        public async Task<UserResponseDto?> FindOneAsync(Guid id)
        {
            var user = await _repo.GetByIdAsync(id);
            if (user is null || !user.IsActive) return null;

            return UserResponseDto.FromEntity(user);
        }

        /// <summary>
        /// Crea un nuevo usuario.
        /// </summary>
        /// <param name="dto">Datos para crear el usuario.</param>
        /// <returns>Usuario creado.</returns>
        public async Task<UserResponseDto> CreateAsync(CreateUserDto dto)
        {
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _repo.Create(user);      
            await _repo.SaveAsyncChanges(); 

            return UserResponseDto.FromEntity(user);
        }

        /// <summary>
        /// Actualiza un usuario existente.
        /// </summary>
        /// <param name="id">Id del usuario.</param>
        /// <param name="dto">Datos a actualizar.</param>
        /// <returns>Usuario actualizado o null si no existe.</returns>
        public async Task<UserResponseDto?> UpdateAsync(Guid id, UpdateUserDto dto)
        {
            var user = await _repo.GetByIdAsync(id);
            if (user is null || !user.IsActive) return null;

            if (!string.IsNullOrWhiteSpace(dto.Name)) user.Name = dto.Name;
            if (!string.IsNullOrWhiteSpace(dto.Email)) user.Email = dto.Email;
            if (dto.IsActive.HasValue) user.IsActive = dto.IsActive.Value;

            user.UpdatedAt = DateTime.UtcNow;

            await _repo.Update(user);       // Marca cambios en memoria
            await _repo.SaveAsyncChanges(); // Persiste en DB

            return UserResponseDto.FromEntity(user);
        }

        /// <summary>
        /// Elimina lógicamente un usuario (soft delete).
        /// </summary>
        /// <param name="id">Id del usuario.</param>
        /// <returns>True si se eliminó, false si no existe.</returns>
        public async Task<bool> RemoveAsync(Guid id)
        {
            var user = await _repo.GetByIdAsync(id);
            if (user is null || !user.IsActive) return false;

            user.IsActive = false;
            user.UpdatedAt = DateTime.UtcNow;

            await _repo.Delete(user);       // Soft delete en memoria
            await _repo.SaveAsyncChanges(); // Persiste en DB
            return true;
        }
    }
}