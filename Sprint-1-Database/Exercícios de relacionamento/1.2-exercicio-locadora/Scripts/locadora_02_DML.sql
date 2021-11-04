
-- DML 1.2 LOCADORA
use locadora;
go

insert into empresa (nomeEmpresa)
values ('Unidos');
go

insert into marca (nomeMarca)
values ('GM'), ('Ford'), ('Fiat');
go

insert into cliente (nomeCliente)
values ('Maria'), ('André'), ('Julia');
go

insert into modelo (idMarca, nomeModelo)
values (1, 'Volt'), (2, 'Mustang'), (3, 'Uno');
go

insert into veiculo (idModelo, descricaoPlaca)
values (1, 'BRA2E19'), (2, 'LSN4I49'), (3, 'BCV6I89');
go

insert into aluguel (idVeiculo, idCliente, dataRetirada, dataDevolucao)
values (1, 3, '05/08/21', '30/08/21'), (2, 1, '12/12/21', '12/01/22'),
(3, 2, '02/04/21', '14/05/21');
go
