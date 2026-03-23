
# API en ASP.NET core v 10

<div style="display: flex; justify-content: center;">
  <img src="https://svgl.app/library/csharp.svg" width="50" alt="C# Logo">
</div>


## Arquitectura modular

La aplicación está organizada en módulos, cada uno de los cuales encapsula una funcionalidad completa.

- **Dtos**:  
  Son las definiciones de Data Transfer Objects. Se utilizan para estructurar y validar los datos que entran y salen de la aplicación, permitiendo una comunicación clara entre el cliente y el servidor.

- **Entities**:  
  Representan las entidades del dominio (por ejemplo, `UserEntity`). Estas clases mapean directamente las tablas de la base de datos y se utilizan para gestionar la persistencia de datos.

- **Services**:  
  Contiene la lógica de negocio relacionada con las entidades. Por ejemplo, en el módulo de usuarios, `UsersService` maneja la validación, procesamiento y reglas de negocio necesarias para gestionar a los usuarios.

- **Controllers**:  
  Son los encargados de exponer los distintos endpoints de la API. Gestionan las peticiones HTTP y utilizan los servicios para procesar la lógica de negocio y devolver respuestas al cliente.

- **Module**:  
  Es el archivo de configuración e inicialización del módulo.

Esta organización en módulos facilita el mantenimiento, la escalabilidad y el aislamiento de funcionalidades, ya que cada sección de la aplicación puede desarrollarse y modificarse de forma independiente. Basada en la arquitectura de ***Nestjs***
(Documentación Nestjs)[https://docs.nestjs.com/modules]

```plaintext
── Modules/
        └── Users/
            ├── Dtos/
            │   ├── CreateUserDto.cs
            │   └── UpdateUserDto.cs
            ├── Entities/
            │   └── UserEntity.cs
            ├── Services/
            │   └── UsersService.cs
            ├── Controllers/
            │   └── UsersController.cs
            └── UserModule.cs
```

***Nota***: Para más información sobre la arquitectura, leer la [documentación](/Documentation/1-Arquitectura.md), dando click.

## Levantar proyecto

1 - Instalar depedencias.

```code
dotnet restore
```


2 - Verficar que proyecto compile.

```code
dotnet build
```

3 - Copiar el archivo ** appsettings.DevelopmentExample.json ** en la raiz y renombrar a ** appsettings.Development.json **.

4 - Hacer la migración 
```
dotnet ef database update --context AppDbContext
```

5 - Levantar el proyecto
```
dotnet watch run
```

## Ver documentacion con Scalar

```code
http://localhost:5063/scalar/v1
```
