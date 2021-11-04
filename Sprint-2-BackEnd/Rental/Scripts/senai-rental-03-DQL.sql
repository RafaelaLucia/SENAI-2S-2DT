use T_Rental;
go

select * from empresa
select * from cliente
select * from marca
select * from modelo
select * from veiculo
select * from aluguel

-- selecionar os clientes, os veículos que eles alugaram e em que dia alugaram
select idAluguel, nomeCliente 'Nome Cliente', sobrenomeCliente 'Sobrenome Cliente', nomeModelo Modelo, placaVeiculo 'Placa Veículo', dataRetirada 'Data de Retirada' from aluguel
inner join cliente on cliente.idCliente = aluguel.idAluguel
inner join veiculo on veiculo.idVeiculo = aluguel.idVeiculo
inner join modelo on veiculo.idModelo = modelo.idModelo

-- selecionar todos os veículos da empresa com suas determinadas marcas e modelos
select idVeiculo, nomeModelo Modelo, nomeMarca Marca, PlacaVeiculo Placa from veiculo
inner join modelo on veiculo.idModelo = modelo.idModelo
inner join marca on modelo.idMarca = marca.idMarca

select idAluguel, veiculo.idVeiculo, cliente.idCliente, placaVeiculo, nomeCliente, dataRetirada from aluguel inner join cliente on cliente.idCliente = aluguel.idCliente inner join veiculo on veiculo.idVeiculo = aluguel.idVeiculo

select dataRetirada, idAluguel, V.idVeiculo, cliente.idCliente from aluguel inner join veiculo V on aluguel.idVeiculo = V.idVeiculo inner join cliente on cliente.idCliente = aluguel.idCliente where aluguel.idAluguel = 2