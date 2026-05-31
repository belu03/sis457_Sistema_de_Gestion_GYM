CREATE TABLE UsuarioSistema (
    id INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    contrasena VARCHAR(100) NOT NULL
);
GO
ALTER TABLE Usuario DROP COLUMN [contraseña];
GO
DECLARE @ConstraintName NVARCHAR(200)
SELECT @ConstraintName = name
FROM sys.default_constraints
WHERE parent_object_id = OBJECT_ID('Usuario')
  AND parent_column_id = (
      SELECT column_id 
      FROM sys.columns 
      WHERE object_id = OBJECT_ID('Usuario') 
        AND name = 'contraseña'
  );

IF @ConstraintName IS NOT NULL
BEGIN
    EXEC('ALTER TABLE Usuario DROP CONSTRAINT ' + @ConstraintName);
END
GO

-- 3. Eliminar finalmente la columna contraseña de la tabla Usuario
ALTER TABLE Usuario DROP COLUMN contraseña;
GO

DECLARE @ConstraintName NVARCHAR(200);
SELECT @ConstraintName = name
FROM sys.default_constraints
WHERE parent_object_id = OBJECT_ID('Usuario')
  AND parent_column_id = (
      SELECT column_id 
      FROM sys.columns 
      WHERE object_id = OBJECT_ID('Usuario') 
        AND name = 'contraseña'
  );

IF @ConstraintName IS NOT NULL
BEGIN
    EXEC('ALTER TABLE Usuario DROP CONSTRAINT ' + @ConstraintName);
END;

-- 3. Eliminar la columna contraseña de la tabla Usuario si todavía existe
IF EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Usuario') AND name = 'contraseña')
BEGIN
    ALTER TABLE Usuario DROP COLUMN contraseña;
END;
SELECT OBJECT_NAME(object_id) AS Objeto_Con_Contrasena
FROM sys.sql_modules
WHERE definition LIKE '%contraseña%' OR definition LIKE '%contrasena%';

INSERT INTO UsuarioSistema (nombre, contraseña) 
VALUES ('admin', 'dAFoRWBCRBpcRyECjAsQqw==');

UPDATE UsuarioSistema 
SET contraseña = '/iWStCpyfpd/BVlHOFtwnMgrFrmof4jGq/OQDWXQzcM=' 
WHERE nombre = 'admin';

-- 1. Renombramos la columna 'tipo' a 'telefono'
EXEC sp_rename 'Usuario.tipo', 'telefono', 'COLUMN';

-- 2. Modificamos el tipo de dato y eliminamos la restricción (CHECK) que tenía 'tipo'
-- Como no podemos borrar la restricción (CHECK) tan fácil, a veces es mejor:
ALTER TABLE Usuario ALTER COLUMN telefono VARCHAR(20);

USE Gimnasio
GO
-- Primero, agregamos la columna telefono (más seguro que renombrar)
ALTER TABLE dbo.Usuario ADD telefono VARCHAR(20);
GO

-- Luego, si ya no quieres la columna 'tipo', simplemente elimínala:
ALTER TABLE dbo.Usuario DROP COLUMN tipo;
GO

ALTER TABLE dbo.Usuario DROP CONSTRAINT CK__Usuario__tipo__5CD6CB2B;
GO

-- Ahora, como la columna ya está libre, podemos borrarla
ALTER TABLE dbo.Usuario DROP COLUMN tipo;
GO

-- Y finalmente agregamos la nueva columna de teléfono
ALTER TABLE dbo.Usuario ADD telefono VARCHAR(20);
GO

SELECT COLUMN_NAME 
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = 'Usuario';

-- Ejecuta esto en tu consulta SQL
DROP TABLE dbo.Recepcionista;
GO

ALTER TABLE Horario ALTER COLUMN hora_inicio TIME;
ALTER TABLE Horario ALTER COLUMN hora_fin TIME;

ALTER TABLE dbo.Horario ALTER COLUMN hora_inicio TIME;
ALTER TABLE dbo.Horario ALTER COLUMN hora_fin TIME;