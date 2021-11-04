-- Selecionar todos os personagens
select * from Personagem

-- Selecionar todas as classes
select * from Classes

-- Selecionar somente o nome das classes
select TipoClasse AS nome_Classes from Classes

-- Selecionar todas as habilidades
select * from Habilidade

-- Realizar a contagem de quantas habilidades estão cadastradas
select COUNT (idHabilidade) AS Habilidades from Habilidade;

-- Selecionar somente os id’s das habilidades classificando-os por ordem crescente
select idHabilidade from Habilidade order by idHabilidade

-- Selecionar todos os tipos de habilidades
select * from TipoHabilidade

-- Selecionar todas as habilidades e a quais tipos de habilidades elas fazem parte
select idHabilidade, TipoHabilidade.idTipo, NomeHabilidade, TipoHabilidade from Habilidade
inner join TipoHabilidade
on TipoHabilidade.idTipo = Habilidade.idTipo

-- Selecionar todos os personagens e suas respectivas classes
select * from Personagem
inner join Classes
on Classes.idClasse = Personagem.idClasse

-- Selecionar todos os personagens e as classes (mesmo que elas não tenham correspondência em personagens);
select nomePersonagem, TipoClasse from Personagem
left join Classes
on Classes.idClasse = Personagem.idClasse

-- Selecionar todas as classes e suas respectivas habilidades
select Classes.idClasse, TipoClasse Classe, NomeHabilidade Habilidade from Classes
inner join HabilidadeClasse
on Classes.idClasse = HabilidadeClasse.idClasse
inner join Habilidade
on Habilidade.idHabilidade = HabilidadeClasse.idHabilidade

-- Selecionar todas as habilidades e suas classes (somente as que possuem correspondência)
select Habilidade.idHabilidade, NomeHabilidade Habilidade, TipoClasse Classse from Habilidade
inner join HabilidadeClasse
on Habilidade.idHabilidade = HabilidadeClasse.idHabilidade
inner join Classes
on HabilidadeClasse.idClasse = Classes.idClasse

-- Selecionar todas as habilidades e suas classes (mesmo que elas não tenham correspondência).
select Habilidade.idHabilidade, NomeHabilidade Habilidade, TipoClasse Classse from Habilidade
full outer join HabilidadeClasse
on Habilidade.idHabilidade = HabilidadeClasse.idHabilidade
full outer join Classes
on HabilidadeClasse.idClasse = Classes.idClasse


--///////////////////////////////////--
select * from tipoUsuario
select * from usuario
select * from usuario inner join tipoUsuario
on tipoUsuario.idTipoUsuario = usuario.idTipoUsuario