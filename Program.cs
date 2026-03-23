using WepAPI.Src;
using WepAPI.Src.Config;

namespace WepAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddOpenApi();
        
        builder.Services.AddAppModules(builder.Configuration); 

        var app = builder.Build();

        //Scalar configuration
        DeveloperToolsConfiguration.UseDevelopmentTools(app);
   
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}