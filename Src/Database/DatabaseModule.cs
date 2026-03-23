using Microsoft.EntityFrameworkCore;

namespace WepAPI.Src.Database;

/// <summary>
/// Configuración de la base de datos y su registro en el contenedor de servicios.
/// </summary>
public static class DatabaseConfiguration
{
    /// <summary>
    /// Agrega el contexto de base de datos usando SQL Server.
    /// </summary>
    /// <param name="services">Colección de servicios de la aplicación.</param>
    /// <param name="configuration">Configuración para obtener la cadena de conexión.</param>
    /// <returns>La colección de servicios actualizada.</returns>
    public static IServiceCollection DatabaseModule(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(10),
                        errorNumbersToAdd: null);
                }));

        return services;
    }
}