use master
go

Create database  DBAeroClub
go

use DBAeroClub
go

Create table  Personas
(
    IdPersona  int primary key identity(1,1),
    Identificacion varchar(20),
    Nombres varchar(200),
    Apellidos varchar(200),
    NombresCompletos varchar(400),
    FechaIngreso datetime,
    Estado varchar(50)
)
go

Create table  Pilotos
(
    IdPiloto  int primary key identity(1,1),
    IdPersona int,
    FechaIngreso datetime,
    Estado varchar(50)
)

Create table  Instructores
(
    IdInstructor  int primary key identity(1,1),
    IdPersona int,
    FechaIngreso datetime,
    Estado varchar(50)
)

Create table  Aeronave
(
    IdAeronave  int primary key identity(1,1),
    IdPersona int,
    FechaIngreso datetime,
    Estado varchar(50)
)


Create table  Horario
(
    IdHorario  int primary key identity(1,1),
    Horario varchar(max),
    FechaIngreso datetime,
    Estado varchar(50)
)


Create table  Vuelos
(
    IdVuelo  int primary key identity(1,1),
    IdInstructor  int,
    IdHorario  int,
    FechaIngreso datetime,
    Estado varchar(50)
)

Create table  PilotoVuelos
(
    IdPilotoVuelos  int primary key identity(1,1),
    IdVuelo  int,
    IdPiloto  int,
    AnioVuelo  int,
    DiaInicio  int,
    DiaFin  int,
    HoraInicio  int,
    HoraFin  int,
    FechaIngreso datetime,
    Estado varchar(50)
)


use DBAeroClub
go

create proc TranPiloto
    @IdPersona int,
    @IdPiloto int
    as
    begin

        ---TODO : de lo que se analcie realziar

        Select 1 as IdMensaje, 'EXITO' as Mensaje

    end