
create database empresa;
go

use empresa;
go

create table pessoa (
 idPessoa smallint primary key identity(1,1),
 nomePessoa varchar(20) not null
 );
 go

 create table telefone (
  idTelefone smallint primary key identity(1,1),
  idPessoa smallint foreign key references pessoa(idPessoa),
  numeroTelefone varchar(15) not null
 );
 go

 create table email (
  idEmail int primary key identity(1,1),
  idPessoa smallint foreign key references pessoa(idPessoa),
  end_email varchar(256) not null 
 );
 go

 create table cnh(
  idCNH smallint primary key identity(1,1),
  idPessoa smallint foreign key references pessoa(idPessoa),
  descricao char(11) not null unique
 );
 go

 --unique nao deixa repetir numero se ja tiver cadastrado