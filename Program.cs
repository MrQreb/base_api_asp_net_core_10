using WepAPI.Src;
using WepAPI.Src.Config;

namespace WepAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        //Configuracion del versionamiento de api
        builder.Services.AddVersioning();

        builder.Services.AddOpenApiConfiguration();  
        
        //Leer los modulos
        builder.Services.AddAppModules(builder.Configuration);

        var app = builder.Build();

        //Configuracion de lenvatar el versionamiento
        app.UseOpenApiConfig();

        //Configuracion de Scalar y mas
        app.UseDevelopmentTools();

        // app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}