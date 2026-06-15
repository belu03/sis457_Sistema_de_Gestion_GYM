# Sistema de Gestión de Gimnasio – GYM La Plata

## Descripción General

El Sistema de Gestión de Gimnasio es una aplicación de escritorio desarrollada en C# con Windows Forms y SQL Server, orientada a la administración integral de un gimnasio. Permite gestionar clientes, membresías, servicios, entrenadores, horarios, reservas e inscripciones, además de controlar el acceso de los clientes y generar reportes gerenciales.

## Objetivo del Sistema

Desarrollar una solución informática que permita automatizar los procesos administrativos y operativos del gimnasio, optimizando el control de clientes, membresías, reservas y accesos, así como proporcionando información útil para la toma de decisiones mediante reportes gerenciales.

## Tecnologías Utilizadas

* Lenguaje de programación: C#
* Framework: .NET Framework
* Interfaz gráfica: Windows Forms
* Base de datos: Microsoft SQL Server
* ORM: Entity Framework Database First
* IDE: Visual Studio 2022

## Arquitectura del Proyecto

El sistema se desarrolló utilizando una arquitectura en capas:

### CadGimnasio

Capa de acceso a datos encargada de la comunicación con la base de datos mediante Entity Framework.

### ClnGimnasio

Capa de lógica de negocio donde se implementan las reglas y procesos del sistema.

### CpGimnasio

Capa de presentación que contiene los formularios y la interfaz gráfica para el usuario.

## Funcionalidades Principales

### Gestión de Clientes

* Registro de clientes.
* Modificación de información.
* Búsqueda de clientes.
* Baja lógica de registros.

### Gestión de Membresías

* Registro y administración de planes de membresía.
* Configuración de precios y duración.

### Gestión de Servicios

* Administración de servicios ofrecidos por el gimnasio.
* Control de capacidad máxima.

### Gestión de Entrenadores

* Registro y administración de entrenadores.
* Control de especialidades.

### Gestión de Inscripciones

* Inscripción de clientes a membresías.
* Registro de pagos.
* Control de vigencia de membresías.

### Gestión de Horarios y Clases

* Programación de horarios.
* Asignación de entrenadores.
* Control de cupos.

### Gestión de Reservas

* Reserva de clases por parte de los clientes.
* Control de asistencia y estado de reservas.

### Control de Acceso

* Registro de ingresos de clientes al gimnasio.
* Historial de accesos.

### Seguridad y Usuarios

* Autenticación mediante usuario y contraseña.
* Roles de Administrador y Recepcionista.
* Contraseñas almacenadas mediante hash SHA-256 con salt.

### Reportes Gerenciales

* Reporte de ingresos por rango de fechas.
* Consultas gerenciales para apoyo a la toma de decisiones.

## Modelo de Datos

El sistema está compuesto por las siguientes entidades principales:

* UsuarioSistema
* Cliente
* Membresia
* Inscripcion
* Servicio
* Entrenador
* HorarioClase
* Reserva
* RegistroAcceso

## Roles del Sistema

### Administrador

Puede gestionar todos los módulos del sistema.

### Recepcionista

Puede realizar operaciones relacionadas con clientes, inscripciones, reservas y control de acceso.

## Alcance del Proyecto

El sistema permite administrar las operaciones esenciales de un gimnasio, incluyendo la gestión de clientes, membresías, servicios, entrenadores, horarios, reservas y accesos. Asimismo, proporciona mecanismos de autenticación y reportes gerenciales que facilitan el control operativo y la toma de decisiones dentro de la organización.
