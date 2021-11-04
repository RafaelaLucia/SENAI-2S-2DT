use T_Rental;
go

insert into empresa (razaoSocial)
values ('Rental');
go

insert into cliente (nomeCliente,sobrenomeCliente) --
values ('Carina','Leone'), ('Paulo','Ventura'), ('Arthur','Cervero');
go

insert into marca (nomeMarca)
values ('GM'), ('Ford'), ('Fiat');
go

insert into modelo (idMarca, nomeModelo)
values (1, 'Onix'), (2, 'Fiesta'), (3, 'Argo');
go

insert into veiculo (idModelo, PlacaVeiculo) --
values (1, 'BRA2E19'), (2, 'LSN4I49'), (3, 'BCV6I89');
go
 
insert into aluguel (idVeiculo, idCliente, dataRetirada) --
values (1, 3, '05/05/21 18:00'), (2, 2, '01/09/21 14:30'),
(3, 1, '20/08/21 12:20');
go



select * from aluguel inner join cliente on aluguel.idCliente = aluguel.idAluguel 
inner join veiculo on veiculo.idVeiculo = aluguel.idVeiculo
select * from veiculo

select idAluguel, veiculo.idVeiculo, cliente.idCliente, Veiculo.placaVeiculo, Cliente.nomeCliente, dataRetirada from aluguel inner join cliente on aluguel.idCliente = aluguel.idAluguel inner join veiculo on veiculo.idVeiculo = aluguel.idVeiculo



