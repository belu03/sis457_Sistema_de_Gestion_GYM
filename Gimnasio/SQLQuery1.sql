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