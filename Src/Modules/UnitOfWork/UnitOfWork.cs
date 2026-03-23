using WepAPI.Src.Database;

namespace WepAPI.Src.Modules.UnitOfWork;

/// <summary>
/// Implementación de la unidad de trabajo usando AppDbContext.
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    /// <summary>
    /// Inicializa una nueva instancia de UnitOfWork.
    /// </summary>
    /// <param name="context">Contexto de base de datos.</param>
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Libera los recursos del contexto de base de datos.
    /// </summary>
    public void Dispose()
    {
        _context.Dispose();
    }

    /// <summary>
    /// Guarda los cambios en la base de datos.
    /// </summary>
    /// <returns>Número de registros afectados.</returns>
    public async Task<int> Save()
    {
        return await _context.SaveChangesAsync();
    }
}