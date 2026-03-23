using Scalar.AspNetCore;

namespace WepAPI.Src.Config
{
    /// <summary>
    /// Configura herramientas de desarrollo para la aplicación web.
    /// </summary>
    /// <param name="app">
    /// Instancia de <see cref="WebApplication"/> sobre la que se aplicarán las configuraciones.
    /// </param>
    /// <returns>
    /// La misma instancia de <see cref="WebApplication"/> para permitir encadenamiento de métodos.
    /// </returns>
    /// <remarks>
    /// Este método solo aplica las configuraciones cuando el entorno es de desarrollo.
    /// En ese caso, se habilitan los endpoints de OpenAPI y la referencia de Scalar.
    /// </remarks>
    public static class DeveloperToolsConfiguration
    {
        public static WebApplication UseDevelopmentTools(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
            }

            return app;
        }
    }

}