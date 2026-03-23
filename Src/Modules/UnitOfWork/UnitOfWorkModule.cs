namespace WepAPI.Src.Modules.UnitOfWork;

/// <summary>
/// Extensiones para registrar los servicios del módulo UnitOfWork.
/// </summary>
public static class UnitOfWorkModule
{
    /// <summary>
    /// Registra la unidad de trabajo en el contenedor de dependencias.
    /// </summary>
    /// <param name="services">Colección de servicios.</param>
    /// <returns>Colección de servicios actualizada.</returns>
    public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}