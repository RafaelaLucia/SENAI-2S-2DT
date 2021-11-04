
-- DML 1.3 PCLINCS
select * from clinica
select * from veterinario
select * from tipo
select * from dono
select * from raca
select * from pet
select * from atendimento

--listar todos os vet(nome e crmv) de uma clinica /*crmv,*/
select nomeVeterinario,nomeClinica from veterinario
inner join clinica 
on veterinario.idClinica = clinica.idClinica;
where clinica.idClinica = 1; --todos os vet da clinica 1, que é a unica q existe

-- listar todas as raças q comeca com a letra s
select * from raca
where nomeRaca like 's%';

-- listar todos os pet que terminam com o
select * from tipo
where nomeTipo like '%o';

- todos os dono
select idPet, nomePet, nomeDono, telefoneDono from pet
left join dono
on pet.idDono = dono.idDono

/*
ALIAS (apelido) 'AS' MUDAR A VISUALIZACAO
caso eu nao tenha colocado nomepet e nomedono e sim nome para ambos
select id.Pet, pet.nome AS pet, dono.nome AS nome from pet
select id.pet pet nao precisa por as so dar espaco
left join dono
on dono.iddono = pet.iddono

*/

--tudo
select idAtendimento, nomeVeterinario, nomePet, nomeRaca [raça], nomeTipo [especie], nomeDono from atendimento
left join veterinario
on veterinario.idVeterinario = atendimento.idVeterinario
inner join pet
on atendimento.idPet = pet.idPet
inner join raca
on pet.idRaca = raca.idRaca
inner join tipo
on raca.idTipo = tipo.idTipo
inner join dono
on pet.idDono = dono.idDono
inner join clinica
on clinica.idClinica = veterinario.idClinica
