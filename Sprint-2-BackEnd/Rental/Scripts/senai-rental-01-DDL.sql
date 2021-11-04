create database T_Rental
use T_Rental

create table empresa(
 idEmpresa int primary key identity,
 razaoSocial varchar(200) not null unique,
);
go

create table cliente(
 idCliente smallint primary key identity,
 nomeCliente varchar(200) not null,
 sobrenomeCliente varchar(200) not null
);
go

create table marca(
 idMarca smallint primary key identity,
 nomeMarca varchar(100) not null
);
go

create table modelo(
 idModelo int primary key identity,
 idMarca smallint foreign key references marca(idMarca),
 nomeModelo varchar(100) not null
);
go

create table veiculo(
 idVeiculo int primary key identity,
 idModelo int foreign key references modelo(idModelo),
 PlacaVeiculo char(10) not null unique
);
go

create table aluguel(
 idAluguel int primary key identity (1,1),
 idVeiculo int foreign key references veiculo(idVeiculo),
 idCliente smallint foreign key references cliente(idCliente),
 dataRetirada datetime not null
);
go

alter table aluguel
drop column dataRetirada
alter table aluguel
add dataRetirada date not null
drop table aluguel