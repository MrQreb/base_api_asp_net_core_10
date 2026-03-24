using Microsoft.OpenApi;

namespace WepAPI.Src.Config
{

    /// <summary>
    /// Proporciona métodos de extensión para configurar OpenAPI (Swagger) en la aplicación.
    /// </summary>
    public static class OpenApiConfiguration
    {
        /// <summary>
        /// Agrega la configuración de OpenAPI al contenedor de servicios.
        /// Registra múltiples versiones de la documentación (v1, v2).
        /// </summary>
        /// <param name="services">Colección de servicios de la aplicación.</param>
        /// <returns>La colección de servicios con OpenAPI configurado.</returns>
        public static IServiceCollection AddOpenApiConfiguration(this IServiceCollection services)
        {
            //Configuracion de open api de open api para las version 1
            services.AddOpenApi("v1", options =>
            {
                options.AddDocumentTransformer((doc, ctx, ct) =>
                {
                    doc.Info = new OpenApiInfo
                    {
                        Title = "Mi API Version 1",
                        Version = "v1",
                    };
                    return Task.CompletedTask;
                });
            });

            //Configuracion de open api de open api para las version 1
            services.AddOpenApi("v2", options =>
            {
                options.AddDocumentTransformer((doc, ctx, ct) =>
                {
                    doc.Info = new OpenApiInfo
                    {
                        Title = "Mi API Version 2",
                        Version = "v2",
                    };
                    return Task.CompletedTask;
                });
            });

        return services;
        }

        /// <summary>
        /// Configura los endpoints necesarios para exponer los documentos OpenAPI.
        /// </summary>
        /// <param name="app">La aplicación web.</param>
        /// <returns>La aplicación web con los endpoints de OpenAPI configurados.</returns>
        public static WebApplication UseOpenApiConfig(this WebApplication app)
        {
            app.MapOpenApi("/openapi/{documentName}.json");
            return app;
        }
    }
}