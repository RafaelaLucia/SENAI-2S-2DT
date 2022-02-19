

use gufi;
go

insert into tipo (tituloTipoUsario)
values ('administrador'),('comum');
go

select * from tipo

insert into usuario (idTipo, nomeUsuario, email, senha)
values (1, 'Laura', 'adm@email.com','senha123'),
(2,'Saulo','saulo@email.com','saulo123'),
(2, 'Lucas','lucas@gmail.com','lucas123');
go

select * from usuario

insert into instituicao (CNPJ,nomeFantasia,endereco)
values ('999999999','Escola SENAI de Informática', 'Barão de Limeira,539');
go

select * from instituicao

insert into tipoEvento (tituloTipoEvento)
values('ReactJS'),('SQL'),('C#');
go

select * from tipoEvento

insert into evento (idTipoEvento, idInstituicao, nomeEvento, descricao, dataEvento)
values (1,1, 'Orientação a Objetos', 'Conceitos sobre os pilares da programação orientada a objetos', '18/08/2021 18:00');
go

insert into evento (idTipoEvento, idInstituicao, nomeEvento, descricao, dataEvento)
values (2,1, 'Ciclo de Vida', 'Como utilizar os ciclos de vida', '19/08/2021 18:30');
go

select * from Evento

insert into situacao (descricao)
values ('Aprovado'),('Recusado'),('Aguardando');
go

select * from situacao

insert into presenca(idUsuario, idEvento, idSituacao)
values (3,1,3),(1,3,1)
go 

select * from presenca

--truncate table usuario, reseta os id

