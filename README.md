# Sistema-de-Gestion-de-Permisos
## Pasos para ejecutar el Sistema de Gestión de Permisos:

**1. Configuración de la base de datos:**

- Abra el archivo `SQL-QUERIES/Create Db.sql` en SQL Server Management Studio.
- Ejecute el script para crear la base de datos y las tablas. 

**2. Compilación del API .NET:**

- Abra la solución `SGP-BACKEND/SGP-BACKEND/SGP-BACKEND.sln` en Visual Studio. 
- Compilar el API abrir la terminal y ejecutar el comando `dotnet build`
- Ejecutar el API abrir la terminal y ejecutar el comando`dotnet run`
- Abra un navegador web y navegue a la dirección `https://localhost:7166/swagger/index.html`.
- Debería ver la interfaz del Swagger.

**4. Inicio del Frontend:**

- Abra una terminal o símbolo del sistema.
- Navegue a la carpeta `/SGP-FRONTEND/sgp-frontend`.
- Instale las dependencias del proyecto con el comando `npm i`.
- Inicie el servidor de desarrollo con el comando `npm run serve`.

**5. Acceso al sistema:**

- Abra un navegador web y navegue a la dirección `http://localhost:8080`.
- Debería ver la interfaz del Sistema de Gestión de Permisos.

**Notas:**

- Asegúrese de tener instalados SQL Server Management Studio, Visual Studio y Node.js.
- Ajuste la configuración de la conexión a la base de datos en el archivo `appsettings.json` del API .NET. 
 
