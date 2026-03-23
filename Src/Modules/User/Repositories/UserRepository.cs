using Microsoft.EntityFrameworkCore;
using WepAPI.Src.Database;
using WepAPI.Src.Modules.Users.Entities;

namespace WepAPI.Src.Modules.Users.Repositories;

/// <summary>
/// Implementación del repositorio de usuarios usando Entity Framework.
/// </summary>
public class UserRepository : IUserRepository
{
    private readonly AppDbContext _db;

    /// <summary>
    /// Inicializa una nueva instancia del repositorio.
    /// </summary>
    /// <param name="db">Contexto de base de datos.</param>
    public UserRepository(AppDbContext db)
    {
        _db = db;
    }

    /// <summary>
    /// Obtiene todos los usuarios.
    /// </summary>
    public async Task<List<User>> GetAllAsync()
    {
        return await _db.Users.ToListAsync();
    }

    /// <summary>
    /// Obtiene un usuario por su Id.
    /// </summary>
    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _db.Users.FindAsync(id);
    }

    /// <summary>
    /// Agrega un nuevo usuario.
    /// </summary>
    public async Task AddAsync(User user)
    {
        await _db.Users.AddAsync(user);
    }

    /// <summary>
    /// Guarda los cambios en la base de datos.
    /// </summary>
    public async Task SaveChangesAsync()
    {
        await _db.SaveChangesAsync();
    }
}