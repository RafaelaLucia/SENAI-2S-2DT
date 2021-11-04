create database SENAI_HROADS_TARDE;
go

use SENAI_HROADS_TARDE;
go

create table Classes (
 idClasse smallint primary key identity (1,1),
 TipoClasse varchar(20) not null
);
go

create table TipoHabilidade (
 idTipo smallint primary key identity (1,1),
 TipoHabilidade varchar(30) not null
);
go

create table Personagem (
 idPersonagem smallint primary key identity (1,1),
 idClasse smallint foreign key references Classes(idClasse),
 nomePersonagem varchar(35) not null,
 MaxMana varchar(10) not null,
 MaxVida varchar(10) not null,
 dataAtualizacao date not null,
 dataCriacao date not null
);
go

create table Habilidade(
 idHabilidade smallint primary key identity (1,1),
 idTipo smallint foreign key references TipoHabilidade(idTipo),
 NomeHabilidade varchar(30) not null
);
go

create table HabilidadeClasse (
 idHabClasse smallint primary key identity (1,1),
 idHabilidade smallint foreign key references habilidade (idHabilidade),
 idClasse smallint foreign key references Classes(idClasse),
);
go
