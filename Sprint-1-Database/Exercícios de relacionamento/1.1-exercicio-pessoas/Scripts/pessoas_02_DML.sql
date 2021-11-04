
-- DML 1.1 PESSOA
use empresa;
go

insert into pessoa (nomePessoa)
values ('Saulo'),('Lucas');
go

insert into telefone (idPessoa, numeroTelefone)
values (1, '999'), (1, '888'), (2,'777');
go

insert into email (idPessoa, end_email)
values (1, 's.santos@email.com'), 
(2, 'l.aragao@email.com');
go

insert into cnh (idPessoa, descricao)
values (1, '1234'), (2, '4334');
go

