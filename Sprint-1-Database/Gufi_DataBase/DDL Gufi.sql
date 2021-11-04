create database gufi;
go

use gufi;
go

create table tipoEvento (
 idTipoEvento int primary key identity,
 tituloTipoEvento varchar(100) unique not null
 );
 go

 create table situacao (
  idSituacao tinyint primary key identity,
  descricao varchar(30) unique not null
 );
 go

 create table instituicao (
  idInstituicao smallint primary key identity,
  CNPJ char(18) unique not null,
  nomeFantasia varchar(100) not null,
  endereco varchar(150) unique not null
 );
 go


 create table evento (
  idEvento int primary key identity,
  idTipoEvento int foreign key references tipoEvento (idTipoEvento),
  idInstituicao smallint foreign key references instituicao (idInstituicao),
  nomeEvento varchar (50) not null,
  descricao varchar (300) not null,
  dataEvento datetime not null,
  acessoLivre bit default (1)
 );
 go

 create table presenca (
  idPresenca int primary key identity,
  idUsuario int foreign key references usuario (idUsuario),
  idEvento int foreign key references evento (idEvento),
  idSituacao tinyint foreign key references situacao (idSituacao)
 );
go



 create table usuario(
 idUsuario int primary key identity,
 idTipo smallint foreign key references tipo (idTipo),
 nomeUsuario varchar(100) not null,
 email varchar(256) unique not null,
 senha varchar(10) not null check( len(senha) >= 8),
 );
 go

create table tipo(
 idTipo smallint primary key identity,
 tituloTipoUsario varchar(50) unique not null
);
go

