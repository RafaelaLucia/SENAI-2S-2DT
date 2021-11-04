create database locadora;
go

use locadora;
go

create table empresa(
 idEmpresa tinyint primary key identity (1,1),
 nomeEmpresa varchar(30) not null
);
go

create table cliente(
 idCliente smallint primary key identity (1,1),
 nomeCliente varchar(20) not null
);
go

create table marca(
 idMarca smallint primary key identity (1,1),
 nomeMarca varchar(30) not null
);
go

create table modelo(
 idModelo int primary key identity (1,1),
 idMarca smallint foreign key references marca(idMarca),
 nomeModelo varchar(50) not null
);
go

create table veiculo(
 idVeiculo smallint primary key identity (1,1),
 idModelo int foreign key references modelo(idModelo),
 descricaoPlaca char(7) not null unique
);
go

create table aluguel(
 idAluguel smallint primary key identity (1,1),
 idVeiculo smallint foreign key references veiculo(idVeiculo),
 idCliente smallint foreign key references cliente(idCliente),
 dataRetirada char(10) not null,
 dataDevolucao char(10) not null
);
go