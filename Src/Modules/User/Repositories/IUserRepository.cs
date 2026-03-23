using WepAPI.Src.Modules.Users.Entities;

namespace WepAPI.Src.Modules.Users.Repositories;

/// <summary>
/// Define las operaciones de acceso a datos para la entidad User.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Obtiene todos los usuarios.
    /// </summary>
    Task<List<User>> GetAllAsync();

    /// <summary>
    /// Obtiene un usuario por su identificador.
    /// </summary>
    /// <param name="id">Id del usuario.</param>
    /// <returns>Usuario encontrado o null.</returns>
    Task<User?> GetByIdAsync(Guid id);

    /// <summary>
    /// Agrega un nuevo usuario.
    /// </summary>
    /// <param name="user">Entidad usuario.</param>
    Task AddAsync(User user);

    /// <summary>
    /// Guarda los cambios en la base de datos.
    /// </summary>
    Task SaveChangesAsync();
}