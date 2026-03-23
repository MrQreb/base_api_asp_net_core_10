namespace WepAPI.Src.Modules.Users;

public static class UsersModule
{
    public static IServiceCollection UserModule(this IServiceCollection services)
    {
     
        services.AddScoped<UsersService>();
        return services;
    }
}