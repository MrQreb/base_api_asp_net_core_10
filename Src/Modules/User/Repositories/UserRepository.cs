using Microsoft.EntityFrameworkCore;
using WepAPI.Src.Database;
using WepAPI.Src.Modules.Users.Entities;

namespace WepAPI.Src.Modules.Users.Repositories
{
    /// <summary>
    /// Repositorio para la entidad User usando Entity Framework.
    /// Compatible con el patrón Unit of Work.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _db;

        /// <summary>
        /// Inicializa el repositorio con el DbContext.
        /// </summary>
        /// <param name="db">Contexto de base de datos.</param>
        public UserRepository(AppDbContext db) => _db = db;

        /// <summary>
        /// Obtiene todos los usuarios activos.
        /// </summary>
        public async Task<List<User>> GetAllAsync()
        {
            return await _db.Users
                .Where(u => u.IsActive) 
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene un usuario por su Id.
        /// </summary>
        /// <param name="id">Id del usuario.</param>
        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _db.Users.FindAsync(id);
        }

        /// <summary>
        /// Agrega un nuevo usuario al contexto (no guarda en la DB aún).
        /// </summary>
        /// <param name="user">Usuario a crear.</param>
        public async Task<User> Create(User user)
        {
            var result = await _db.Users.AddAsync(user);
            return result.Entity; 
        }

        /// <summary>
        /// Actualiza una entidad existente (cambia propiedades en memoria).
        /// </summary>
        /// <param name="entity">Usuario con cambios.</param>
        public Task Update(User entity)
        {
            _db.Users.Update(entity);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Elimina un usuario (soft delete marcando IsActive = false)
        /// </summary>
        /// <param name="entity">Usuario a eliminar.</param>
        public Task Delete(User entity)
        {
            entity.IsActive = false; // Soft delete
            _db.Users.Update(entity);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Elimina un usuario por Id (soft delete)
        /// </summary>
        /// <param name="id">Id del usuario.</param>
        public async Task<User?> DeleteById(Guid id)
        {
            var user = await GetByIdAsync(id);
            if (user != null)
            {
                user.IsActive = false;
                _db.Users.Update(user); // Prepara el cambio
            }
            return user;
        }

        /// <summary>
        /// Verifica si existe un usuario por Id.
        /// </summary>
        public async Task<bool> CheckIfExistById(Guid id)
        {
            return await _db.Users.AnyAsync(u => u.Id == id && u.IsActive);
        }

        /// <summary>
        /// Guarda todos los cambios pendientes en la base de datos.
        /// Esto será llamado desde UnitOfWork.
        /// </summary>
        public Task SaveAsyncChanges()
        {
            return _db.SaveChangesAsync();
        }
    }
}