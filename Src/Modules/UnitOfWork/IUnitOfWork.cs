namespace WepAPI.Src.Modules.UnitOfWork;

/// <summary>
/// Define una unidad de trabajo para manejar transacciones en la base de datos.
/// </summary>
public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Guarda los cambios realizados en la base de datos.
    /// </summary>
    /// <returns>Número de registros afectados.</returns>
    Task<int> Save();
}


