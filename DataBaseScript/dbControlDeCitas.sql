create database dbControlDeCitas;
use dbControlDeCitas;

create table tbAdministradores(
	IdAdministrador int unique identity not null,
	Nombre nvarchar(50),
	ApellidoPaterno nvarchar(50),
	ApellidoMaterno nvarchar(50),
	NumControl int not null,
	Contraseña nvarchar(10) not null,
	constraint PK_tbAdministradores_IdAdministrador primary key (IdAdministrador)
);

insert into tbAdministradores(Nombre, NumControl, Contraseña) values ('Betina', 30303030, '30303030'); 

create table tbUsuarios(
	IdUsuario int unique identity not null,
	IdAdministrador int not null,
	Nombre nvarchar(50),
	ApellidoPaterno nvarchar(50),
	ApellidoMaterno nvarchar(50),
	NumControl int not null,
	Contraseña nvarchar(10) not null,
	constraint PK_tbUsuarios_IdUsuario primary key (IdUsuario),
	constraint FK_tbUsuarios_IdAdministrador foreign key (IdAdministrador)
		references tbAdministradores(IdAdministrador) on delete cascade on update cascade
);

insert into tbUsuarios(IdAdministrador, Nombre, NumControl, Contraseña) values (1, 'Alejandro', 12330529, '12330529');
insert into tbUsuarios(IdAdministrador, Nombre, NumControl, Contraseña) values (1, 'Luis', 12330488, '12330488');
insert into tbUsuarios(IdAdministrador, Nombre, NumControl, Contraseña) values (1, 'Leonardo', 12330486, '12330486');

create table tbCitas(
	IdCita int unique identity not null,
	IdUsuario int,
	IdAdministrador int not null,
	Hora nvarchar(10) not null,
	Dia date not null,
	FechaAgendada date default getdate(),
	Disponible int default 0, /*0 es no disponible, 1 disponible, 2 Ya expliro o elimino*/
	Comentario nvarchar(MAX) default '',
	constraint PK_tbCitas_IdCita primary key (IdCita),
	constraint FK_tbCitas_IdUsuario foreign key (IdUsuario)
		references tbUsuarios(IdUsuario),
	constraint FK_tbCitas_IdAdministrador foreign key (IdAdministrador)
		references tbAdministradores(IdAdministrador) on delete cascade on update cascade
);

insert into tbCitas(IdAdministrador, Hora, Dia) values (1, '11:10 am', '29/05/2015');
insert into tbCitas(IdAdministrador, Hora, Dia) values (1, '11:30 am', '29/05/2015');
insert into tbCitas(IdAdministrador, Hora, Dia) values (1, '12:00 pm', '29/05/2015');
insert into tbCitas(IdAdministrador, Hora, Dia) values (1, '12:20 pm', '29/05/2015');

/*
create table tbMaterias(
	IdMateria int unique identity not null,
	Materia nvarchar(50),
	Maestro nvarchar(50),
);
*/

/*
create table tbCitas(
	IdCita int unique identity not null,
	IdUsuario int unique not null,
	IdAdministrador int not null,
	FechaAgendada date,
	FechaAgregada date default getdate(),
	Comentario nvarchar(MAX)
	constraint PK_tbCitas_IdCita primary key (IdCita),
	constraint FK_tbCitas_IdUsuario foreign key (IdUsuario)
		references tbUsuarios(IdUsuario) on delete cascade on update cascade,
	constraint FK_tbCitas_IdAdministrador foreign key (IdAdministrador)
		references tbAdministradores(IdAdministrador)
);*/