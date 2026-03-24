using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace WepAPI.Src.Config
{
    /// <summary>
    /// Proporciona métodos de extensión para configurar el versionado de la API.
    /// </summary>
    public static class VersioningConfiguration
    {

        /// <summary>
        /// Agrega la configuración de versionado de la API al contenedor de servicios.
        /// Define una versión por defecto y habilita el explorador de versiones.
        /// </summary>
        /// <param name="services">Colección de servicios de la aplicación.</param>
        /// <returns>La colección de servicios con el versionado configurado.</returns>
        public static IServiceCollection AddVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                /// <summary>
                /// Establece la versión por defecto de la API cuando no se especifica una.
                /// </summary>
                options.DefaultApiVersion = new ApiVersion(1, 0);

            });

            services.AddVersionedApiExplorer(options =>
            {
                /// Define el formato del nombre del grupo (por ejemplo: v1, v2).
                options.GroupNameFormat = "'v'V";

                /// Sustituye la versión en la URL automáticamente cuando se usa en rutas.
                options.SubstituteApiVersionInUrl = true;
            });

            return services;
        }
    }
}