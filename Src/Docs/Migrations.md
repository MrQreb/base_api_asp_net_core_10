### Correr proyecto en hot realod
dotnet watch run

### Crear migraciones
dotnet ef migrations add ***NombreDeMigracion** --context AppDbContextAutenticacion --output-dir Migrations/Autenticacion

### Actualizar la base de datos para reflejar la migración.
dotnet ef database update --context AppDbContextAutenticacion
 
### Borrrar la base de datps actual y aplicar todas las migraciones
dotnet ef database drop --force --context AppDbContextMantenimiento
dotnet ef database update --context AppDbContextMantenimiento
 
### Aplicar una migracion por nombre
dotnet ef database update 20250527182302_AdvertenciaNewFilds --context AppDbContextMantenimiento

### Acceder a la documentación con Swagger
- Tener el modo de desarrollo en ***launchSettings.json***
- Acceder a la url:***http://localhost:5134/swagger/index.html***

### Obtener los modelos de una base de datos
dotnet ef dbcontext scaffold "Name=NombreConexion" Microsoft.EntityFrameworkCore.SqlServer -o Models -t NombreTabla1 -t NombreTabla2
***ejemplo***: dotnet ef dbcontext scaffold "Name=SAPConnection" Microsoft.EntityFrameworkCore.SqlServer -o Models -t IGE1 -t OIGE

### Obtener nuevos modelos de contexto ya existente
dotnet ef dbcontext scaffold "Name=SAPConnection" Microsoft.EntityFrameworkCore.SqlServer -o TempModels -t NuevaTabla

## Eliminar ultima migración sin aplicar 
dotnet ef migrations remove --context AppDbContextNombreContexto

## Lista de migraciones 
dotnet ef migrations list --context AppDbContextAutenticacion  

## Eliminar migracion con nombre
dotnet ef migrations remove --context AppDbContextNombreContexto

## Volver a una migracion
dotnet ef database update 20250728180715_CargoAreaTableAdded --context AppDbContextAutenticacion

## Librerias usadas en el proyecto

### Externas 

- [**QuestPDF**](https://www.questpdf.com/)  
  Biblioteca para la generación de documentos PDF de manera programática en .NET, permitiendo crear reportes y documentos personalizados con facilidad.

- [**QRCoder**](https://github.com/codebude/QRCoder/wiki#11-how-to-use-qrcoder)  
  Biblioteca para la generación de códigos qr.

- [**Twilio**](https://www.twilio.com/docs/libraries/reference/twilio-csharp/)  
  SDK oficial de Twilio para .NET, utilizado para enviar mensajes SMS, realizar llamadas telefónicas y manejar otros servicios de comunicación proporcionados por Twilio.

- [**Magick.NET-Q8-AnyCPU**](https://github.com/dlemstra/Magick.NET/tree/main/docs)  
  Biblioteca para leer, escribir y transformar imágenes en múltiples formatos. Usada para disminuir el peso de las imagenes en el sistema

- [**MailKit**](https://ironpdf.com/blog/net-help/mailkit-csharp-guide/#trial-license)  
  Envio de correros que soporta protocolos SMTP, POP3 e IMAP. Se utiliza para enviar y recibir correos electrónicos de manera segura y eficiente.

### Microsoft

- [**Microsoft.AspNetCore.Authentication.JwtBearer**](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.authentication.jwtbearer?view=aspnetcore-9.0)

Permite validación y creación de tokens JWT enviados por los clientes. Facilitando la protección de rutas y recursos, asegurando que solo usuarios autenticados (con un token válido) puedan acceder a ciertos endpoints. 

- [**Microsoft.AspNetCore.OpenApi*](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/openapi/aspnetcore-openapi?view=aspnetcore-9.0&tabs=visual-studio%2Cvisual-studio-code)  
  Proporciona herramientas y utilidades para trabajar con especificaciones OpenAPI (Swagger) en aplicaciones ASP.NET Core, facilitando la documentación y prueba de APIs.

- [**Microsoft.EntityFrameworkCore**](https://learn.microsoft.com/en-us/ef/)  
  ORM (Object-Relational Mapper) de Microsoft para .NET, que permite interactuar con bases de datos relacionales utilizando objetos .NET y LINQ.

- [**Microsoft.EntityFrameworkCore.SqlServer**](https://learn.microsoft.com/en-us/ef/) 
  Proveedor de Entity Framework Core para bases de datos SQL Server, permitiendo que la aplicación utilice SQL Server como sistema de almacenamiento de datos.

- **Microsoft.EntityFrameworkCore.Tools**  
  Herramientas de línea de comandos y utilidades para facilitar tareas de desarrollo con Entity Framework Core, como migraciones y scaffolding.

- **Swashbuckle.AspNetCore**  
  Herramienta para generar documentación interactiva de APIs RESTful en ASP.NET Core utilizando Swagger/OpenAPI, permitiendo probar los endpoints desde una interfaz web.


# Eliminar librerias en Asp net core.

- dotnet remove package Microsoft.Graph
- dotnet restore

# Crear build y montar en IIS.
1. Poner comando ```dotnet publish -c Release -o ./publish```.
1. Copiar la carpetea de produccion y ponerla en directorio de IIS.
3. Montar la carpeta en IIS y seleccionar el puerto.
