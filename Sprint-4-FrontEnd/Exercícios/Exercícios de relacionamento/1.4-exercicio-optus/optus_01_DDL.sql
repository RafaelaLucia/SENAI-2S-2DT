
create database plataforma;
go

use plataforma;
go

create table plataforma (
 idPlataforma tinyint primary key identity(1,1),
 nomePlataforma varchar(25) not null
);
go

create table cliente (
 idCliente smallint primary key identity(1,1),
 nomeCliente varchar(20) not null
);
go

create table 