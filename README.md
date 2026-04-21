# sis457_Sistema_de_Gestion_GYM
Sistema de Gestión de Gimnasio - Plataforma Web

Descripción del Negocio

Somos un gimnasio que ofrece una plataforma web para la gestión eficiente de sus servicios, permitiendo a los usuarios acceder a clases como zumba, pilates y entrenamiento físico, así como realizar reservas en horarios disponibles. El sistema busca optimizar la administración del gimnasio y mejorar la experiencia de los clientes.

Objetivo del Sistema

Desarrollar una página web que permita gestionar usuarios, servicios, horarios, reservas, pagos y asistencia, facilitando la organización y control de actividades del gimnasio.

Funcionalidades Principales

- Registro e inicio de sesión de usuarios
- Visualización de servicios (zumba, pilates, etc.)
- Consulta de horarios disponibles
- Reserva de clases
- Gestión de membresías
- Registro de pagos
- Control de asistencia
- Panel de administración

Entidades del Sistema (8 tablas)

1. Usuario

- id_usuario
- nombre
- apellido
- correo
- contraseña
- tipo (cliente/admin)

2. Entrenador

- id_entrenador
- nombre
- apellido
- telefono
- especialidad
- correo

3. Servicio

- id_servicio
- nombre
- descripcion
- duracion
- capacidad_maxima

4. Horario

- id_horario
- dia
- hora_inicio
- hora_fin
- id_servicio
- id_entrenador

5. Reserva

- id_reserva
- fecha
- estado
- id_usuario
- id_horario

6. Membresia

- id_membresia
- tipo
- precio
- duracion
- id_usuario

7. Pago

- id_pago
- monto
- fecha
- metodo_pago
- id_usuario
- id_membresia

8. Asistencia

- id_asistencia
- fecha
- estado (asistió / no asistió)
- id_usuario
- id_horario

Alcance del Proyecto

El sistema permitirá gestionar reservas, pagos y control de asistencia dentro del gimnasio, mejorando la organización, control de usuarios y eficiencia administrativa.
