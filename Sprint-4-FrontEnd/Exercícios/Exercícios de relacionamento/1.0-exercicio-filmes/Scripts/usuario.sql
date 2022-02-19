use catalogo

Create table usuarios(
idUsuario int primary key identity,
email varchar(100) not null unique,
senha varchar(10) not null,
permissao varchar(30) not null
);
go

insert into usuarios (email, senha, permissao)
values ('lucas@email.com', '123', 'comum'),
('adm@email.com', '123', 'administrador');
go

select * from usuarios

--> 

select * from usuarios where email = 'adm@email.com' 
