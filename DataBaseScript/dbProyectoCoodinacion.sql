create database dbProyectoCoordinacion;

create table tbCarreras(
	IdCarrera int unique identity not null,
	IdReticula int unique,
	Nombre nvarchar(50),
	constraint PK_tbCarreras_IdCarrera primary key (IdCarrera)
);

create table tbRoles(
	IdRol int unique identity not null,
	Tipo nvarchar(30),
	constraint PK_tbRoles_IdRol primary key (IdRol)
);

create table tbUsuarios(
	IdUsuario int unique not null,
	IdCarrera int not null,
	IdRol int not null,
	Nombre nvarchar(50),
	Apellidos nvarchar(50),
	Contraseña nvarchar(10) not null,
	constraint PK_tbUsuarios_IdUsuario primary key (IdUsuario),
	constraint FK_tbUsuarios_IdCarrera foreign key (IdCarrera)
		references tbCarreras(IdCarrera) on delete cascade on update cascade,
	constraint FK_tbUsuarios_IdRol foreign key (IdRol)
		references tbRoles(IdRol) on delete cascade on update cascade
);

create table tbCitas(
	IdCita int unique identity not null,
	IdCoordinador int not null,
	IdUsuario int,
	FechaAgendada datetime,
	FechaDisponible datetime,
	Estado int default 0, /*0 disponible, 1 ocupada, 2 expiro, 3 elimino*/
	Comentario nvarchar(MAX) default '',
	constraint PK_tbCitas_IdCita primary key (IdCita)
);

create table tbMotivos(
	IdMotivo int unique identity not null,
	IdCarrera int not null,
	Motivo nvarchar(MAX),
	constraint PK_tbMotivos_IdMotivo primary key(IdMotivo),
	constraint FK_tbMotivos_IdCarrera foreign key(IdCarrera)
		references tbCarreras(IdCarrera) on update cascade
);

create table tbRelacionMotivosCitas(
	IdCita int not null,
	IdMotivo int not null,
	constraint FK_tbRelacionMotivosCitas_IdCita foreign key(IdCita)
		references tbCitas(IdCita) on update cascade,
	constraint FK_tbRelacionMotivosCitas_IdMotivo foreign key(IdMotivo)
		references tbMotivos(IdMotivo) on update cascade
);