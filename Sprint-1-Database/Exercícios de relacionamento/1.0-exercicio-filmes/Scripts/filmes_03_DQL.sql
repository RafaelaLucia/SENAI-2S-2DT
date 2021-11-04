use catalogo;
go

select * from filme;
select * from genero;

/*
 SELECT campo1, campo2, campo3
 FROM tabela1
 TIPO (INNER, RIGTH..) JOIN tabela2
 ON tabela1.campo1 (PK,FK) = tabela2.campo2 (FK,PK)
*/

-- (LEFT JOIN) Listar todos os filmes mostrando o nome do g�nero de cada um mesmo que um filme n�o possua um g�nero atrelado
-- select * from filme 
   select idFilme, tituloFilme, nomeGenero from filme
   left join genero
   on filme.idGenero = genero.idGenero;

-- (RIGTH JOIN) Listar somente filmes que possuam g�nero, trazendo tamb�m todos os g�neros que n�o representam algum filme
    select idFilme, tituloFilme, nomeGenero from filme
	right join genero
	on filme.idGenero = genero.idGenero;

-- (INNER JOIN) Listar somente os filmes que possuam um g�nero definido; G�neros que n�o correspondam a um filme n�o devem ser mostrados
   select idFilme, tituloFilme, nomeGenero from filme
   inner join genero
   on filme.idGenero = genero.idGenero;

-- (FULL OUTER) Listar todos os filmes e todos os g�neros mesmo que n�o haja correspond�ncia entre eles
   select idFilme, tituloFilme, nomeGenero from filme
   full outer join genero
   on filme.idGenero = genero.idGenero;
