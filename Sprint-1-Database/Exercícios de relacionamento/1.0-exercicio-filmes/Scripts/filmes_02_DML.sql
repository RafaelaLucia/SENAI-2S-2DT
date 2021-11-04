
-- DML 1.0 FILMES
use catalogo;
go

insert into genero (nomeGenero)
values ('ação'), ('romance');
go

insert into genero (nomeGenero)
values ('aventura'), ('terror');
go

delete from genero
where idGenero = 2

insert into filme (tituloFilme, idGenero)
values ('Rambo',1), ('Vingadores',1),
('Ghost',3), ('Diario de uma paixao',3);
go

insert into filme (tituloFilme, idGenero)
values ('HER',null), ('Homem-Aranha',null);
go

/*
deletar duas ou mais linhas:
delete from filme
where idFilme in(2,3)
*/

--trocar uma informação da tabela:
update filme set tituloFilme = 'Rambo 2'
where idFilme = 1