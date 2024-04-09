IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'PermisosEmpleadosDb')
BEGIN
    CREATE DATABASE PermisosEmpleadosDb;
END
GO

USE PermisosEmpleadosDb;
GO

-- Tabla para almacenar los tipos de permisos
CREATE TABLE TipoPermiso (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion NVARCHAR(200) NOT NULL
);

-- Tabla para almacenar los permisos solicitados
CREATE TABLE Permisos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NombreEmpleado VARCHAR(50) NOT NULL,
    ApellidosEmpleado VARCHAR(50) NOT NULL,
    TipoPermiso INT NOT NULL,
    FechaPermiso DATE NOT NULL,
    CONSTRAINT FK_TipoPermiso FOREIGN KEY (TipoPermiso) REFERENCES TipoPermiso(Id)
);

-- Insertar datos en la tabla TipoPermiso
 
INSERT INTO TipoPermiso (Descripcion) VALUES ('Enfermedad');
INSERT INTO TipoPermiso (Descripcion) VALUES ('Diligencias');
INSERT INTO TipoPermiso (Descripcion) VALUES ('Otros');
 
