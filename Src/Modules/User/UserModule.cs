using WepAPI.Src.Modules.Users.Repositories;

namespace WepAPI.Src.Modules.Users;


/// <summary>
/// Registra las contenedor de dependencias de usuarios.
/// </summary>
/// <param name="services">Colección de servicios.</param>
/// <returns>Colección de servicios actualizada.</returns>
public static class UsersModule
{
    public static IServiceCollection UserModule(this IServiceCollection services)
    {

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<UsersService>();
        return services;
    }
}