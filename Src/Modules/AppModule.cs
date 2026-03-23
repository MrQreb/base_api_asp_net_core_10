using WepAPI.Src.Database;
using WepAPI.Src.Modules.Users;

namespace WepAPI.Src;

public static class AppModule
{
    public static IServiceCollection AddAppModules(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .AddDatabase(configuration) 
            .AddUsersModule();
        return services;
    }
}