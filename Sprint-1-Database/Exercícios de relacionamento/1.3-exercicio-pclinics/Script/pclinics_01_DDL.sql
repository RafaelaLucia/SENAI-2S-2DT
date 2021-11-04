
create database veterinario;
go

use veterinario;
go

create table clinica(
 idClinica tinyint primary key identity(1,1),
 nomeClinica varchar(35) not null
);
go

create table veterinario(
 idVeterinario smallint primary key identity(1,1),
 nomeVeterinario varchar(20) not null
 --id clinica
);
go

create table tipo(
 idTipo smallint primary key identity(1,1),
 nomeTipo varchar(35) not null
);
go

create table dono(
 idDono smallint primary key identity(1,1),
 nomeDono varchar(20) not null,
 telefoneDono varchar(15) not null
);
go

create table raca(
 idRaca smallint primary key identity(1,1),
 idTipo smallint foreign key references tipo(idTipo),
 nomeRaca varchar(35) not null
);
go

create table pet(
 idPet smallint primary key identity(1,1),
 idDono smallint foreign key references dono(idDono),
 idRaca smallint foreign key references raca(idRaca),
 nomePet varchar(20) not null
);
go

create table atendimento(
 idAtendimento smallint primary key identity(1,1),
 idVeterinario smallint foreign key references veterinario(idVeterinario),
 idPet smallint foreign key references pet(idPet),
 horarioAtendimento varchar(20) not null
);
go