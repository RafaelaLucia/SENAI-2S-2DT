--comentario de uma linha 

/*
comentario de
varias linhas
eba
*/

---CRIA UM BANCO DE DADOS CHAMADO CATALOGO.
create database catalogo;
go

---MUDA DE MASTER PARA CATALOGO
use catalogo;
go

create table genero (
 idGenero tinyint primary key identity(1,1),
 nomeGenero varchar(20) 
);
go

alter table genero
add nomeGenero varchar(20) not null

create table filme(
 idFilme smallint primary key identity(1,1),
 idGenero tinyint foreign key references genero(idGenero),
 tituloFilme varchar(50) not null
);