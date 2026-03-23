namespace WepAPI.Src.Modules.Users;

public static class UsersModule
{
    public static IServiceCollection AddUsersModule(this IServiceCollection services)
    {
        // Singleton porque la lista en memoria vive toda la app
        // Cuando agregues EF Core, cambia a Scoped
        services.AddScoped<UsersService>();
        return services;
    }
}