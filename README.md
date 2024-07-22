# Cliente API

Esta es una API para gestionar clientes, construida utilizando .NET 8

## Requisitos

Antes de empezar, asegúrate de tener instalados los siguientes programas y herramientas:

1. **.NET 8 SDK**: Necesario para compilar y ejecutar el proyecto.
2. **SQL Server**: Utilizado como base de datos.
3. **Visual Studio 2022** (o una versión más reciente).
4. **Postman** (opcional): Para probar los endpoints de la API.

## Configuración del Proyecto
### Clonar el Repositorio
```
git clone https://github.com/ikariano/RetoTecnicoPromart.git
```
### Configurar la Cadena de Conexión
Asegúrate de configurar la cadena de conexión a tu base de datos SQL Server en el archivo 'appsettings.json':
```
{
  "ConnectionStrings": {
    "Conexion": "Server=SERVER\\SQL2022;Database=NombreDDBB;User Id=sa;Password=***;TrustServerCertificate=True;"
  }
}
```
### Restaurar Paquetes de NuGet
Ejecuta el siguiente comando en la raíz del proyecto para restaurar los paquetes necesarios:
```
dotnet restore
```
### Aplicar Migraciones de la Base de Datos
Ejecuta los siguientes comandos en la consola del Administrador de Paquetes de NuGet para crear y aplicar la migración inicial:
```
Add-Migration v1_CrearTablas
Update-Database
```

## Endpoints de la API
### - Crear Cliente
| Tipo    | EndPoint    | Cuerpo       |
|:------------ |:------------ |:------------:|
|```POST```|```/RetoTecnico/CrearCliente```|```{"Nombre": "Juan",  "Apellidos": "Pérez",  "FechaNacimiento": "2024-07-21"}```|
### - Listar Clientes
| Tipo    | EndPoint    | Cuerpo       |
|:------------ |:------------ |:------------:|
|```GET```|```/RetoTecnico/ListarClientes```|No necesita|
### - Obtener cliente específico por IdCliente
| Tipo    | EndPoint    | Cuerpo       |
|:------------ |:------------ |:------------:|
|```GET```|```/RetoTecnico/ObtenerCliente/{IdCliente}```|No necesita|
### - Obtener los 3 clientes con mayor edad.
| Tipo    | EndPoint    | Cuerpo       |
|:------------ |:------------ |:------------:|
|```GET```|```/RetoTecnico/ObtenerClientesMayorEdad```|No necesita|

