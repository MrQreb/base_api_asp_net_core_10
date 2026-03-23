using WepAPI.Src.Modules.Users.Repositories;

namespace WepAPI.Src.Modules.Users;

public static class UsersModule
{
    public static IServiceCollection UserModule(this IServiceCollection services)
    {

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<UsersService>();
        return services;
    }
}