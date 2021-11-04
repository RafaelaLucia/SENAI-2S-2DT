
use empresa;
go

-- DQL 1.1 PESSOA
select * from pessoa
select * from email
select * from telefone
select * from cnh

--dupliquei tudo sem querer D:
delete from pessoa
where idPessoa in(3,4)

delete from email
where idEmail in(3,4)

delete from telefone
where idTelefone in(4,5,6)

--jhjhjhj
  select numeroTelefone,nomePessoa, end_email, cnh from telefone
  left join pessoa
  on pessoa.idPessoa = telefone.idPessoa;
  rigth join pessoa
  on email.idPessoa = Pessoa.idPessoa;