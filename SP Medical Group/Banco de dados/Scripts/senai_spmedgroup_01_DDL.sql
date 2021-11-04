create database SP_Medical_Group;
go

use SP_Medical_Group;
go

create table Clinica(
 idClinica smallint primary key identity,
 nomeClinica varchar(200) not null,
 CNPJ char(18) unique not null,
 razaoSocial varchar(110) unique not null,
 endereco varchar(150) unique not null,
  idUsuario int foreign key references Usuario (idUsuario)
);
go 

alter table clinica
add idUsuario int foreign key references Usuario (idUsuario)
drop table clinica

create table Especialidades(
 idEspecialidades tinyint primary key identity,
 descricaoEspecialidade varchar(100) not null
);
go

create table Situacao(
 idSituacao tinyint primary key identity,
 descricaoSituacao varchar(60) not null
);
go

create table tipoUsuario (
 idTipo smallint primary key identity,
 descricaoTipo varchar(60) not null
);
go

create table Paciente (
 idPaciente int primary key identity,
 idUsuario int foreign key references Usuario (idUsuario),
 nomePaciente varchar(100) not null,
 dataNascimento date not null,
 CPF char(20) unique not null,
 enderecoPaciente varchar(150) not null,
 Telefone varchar(30),
 RG char(20) unique not null
);
go

alter table paciente
add RG char(20) unique not null;
go

drop table consulta
drop table usuario
drop table paciente
drop table medico


create table Medico (
 idMedico int primary key identity,
 idClinica smallint foreign key references Clinica (idClinica),
 idUsuario int foreign key references Usuario (idUsuario),
 idEspecialidades tinyint foreign key references Especialidades (idEspecialidades),
 nomeMedico varchar(100) not null,
 CRM char(10) unique not null
);
go

create table Consulta (
 idConsulta int primary key identity,
 idSituacao tinyint foreign key references Situacao (idSituacao),
 idMedico int foreign key references Medico (idMedico),
 idPaciente int foreign key references Paciente (idPaciente),
 dataConsulta datetime not null
);
go
drop table consulta

alter table consulta
add descricao varchar(300) 

create table Usuario (
 idUsuario int primary key identity,
 idTipo smallint foreign key references tipoUsuario (idTipo),
 enderecoEmail varchar(256) unique not null,
 senha varchar(10) not null 
);
go

drop table usuario
drop table paciente
drop table medico
drop table consulta

create table imagemUsuario(
id int primary key identity(1,1),
idUsuario int not null unique foreign key references usuario(idUsuario),
binario varbinary(max) not null,
mimetype varchar(30) not null,
nomeArquivo varchar(250) not null,
data_inclusao datetime default getdate() null
);
go
drop table imagemUsuario

