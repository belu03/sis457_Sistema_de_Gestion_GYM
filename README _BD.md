# sis457_Sistema_de_Gestion_GYM
S# Configuración de la Base de Datos

## Flujo de instalación para nuevos integrantes

### 1. Clonar el repositorio

Clonar el proyecto desde GitHub y abrir la solución en Visual Studio.

### 2. Crear la base de datos

Abrir SQL Server Management Studio (SSMS) y ejecutar el archivo: ddl_dml_gimnasio.sql

Este script realizará automáticamente las siguientes acciones:

- Creación de la base de datos `Gimnasio`.
- Creación del usuario SQL `usrgimnasio`.
- Creación de tablas, relaciones y procedimientos almacenados.
- Inserción de datos de prueba necesarios para el sistema.

### 3. Ejecutar la aplicación

Una vez ejecutado el script, abrir la solución en Visual Studio y ejecutar el proyecto.

No es necesario modificar el archivo `App.config`, ya que la aplicación está configurada para conectarse automáticamente utilizando:

- Servidor: `localhost`
- Base de datos: `Gimnasio`
- Usuario SQL: `usrgimnasio`

### 4. Uso de SQL Server Management Studio (Opcional)

La aplicación funciona de manera independiente y no requiere que SQL Server Management Studio permanezca abierto.

SSMS solo será necesario para:

- Ejecutar el script de creación de la base de datos.
- Consultar información directamente en la base de datos.
- Realizar pruebas o mantenimiento.

Para conectarse manualmente desde SSMS utilizar:

- Servidor: `localhost`
- Tipo de autenticación: `Autenticación de SQL Server`
- Usuario: `usrgimnasio`
- Contraseña: `123456`

## Importante

La ejecución del archivo `ddl_dml_gimnasio.sql` elimina y recrea la base de datos `Gimnasio`. Por lo tanto, si se vuelve a ejecutar el script, toda la información registrada anteriormente será reemplazada por los datos iniciales definidos en el mismo.

