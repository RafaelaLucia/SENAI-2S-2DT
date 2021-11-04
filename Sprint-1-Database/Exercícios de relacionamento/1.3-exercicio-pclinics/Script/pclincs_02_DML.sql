
-- DML 1.3 PCLINCS
use veterinario;
go

insert into clinica (nomeClinica)
values ('PClinics');
go

insert into veterinario (nomeVeterinario)
values ('Gabi'),('Suelli'),('Renan');
go

insert into tipo (nomeTipo)
values ('Pássaro'),('Hamster'),('Gato'),('Cachorro');
go

insert into dono (nomeDono, telefoneDono)
values ('Laura', '(11)111-11'),('Cláudio','(11)222-22'),('Yasmin','(11)333-33'),('José','(11)444-44');
go

insert into raca (idTipo, nomeRaca)
values (2,'Sírio'),(3,'RagDoll'),(4,'Pastor-Alemão'),(1,'Calopsita');
go

insert into pet (idDono, idRaca, nomePet)
values (2,3, 'Thor'),(3,2,'Chico'),(4,4,'Neves'),(1,1,'Biscoito');
go

insert into atendimento (idVeterinario, idPet, horarioAtendimento)
values (1,1, '11:39 - 13:00'),(2,3,'12:20 - 13:12'),(3,2,'13:13 - 14:25'),(1,4,'15:30 - 16:40')
go

