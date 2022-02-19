use roman_bd;

INSERT INTO tipoUsuario(tituloTipoUsuario)
VALUES('Administrador'),('Professor')
GO

INSERT INTO usuario(idTipoUsuario,email,senha)
VALUES (2,'saulo@gmail.com','saulo1234'),(2,'lucas@gmail.com','lucas1234'),
(1,'adm@adm.com','adm132')
GO

INSERT INTO equipe(nomeEquipe)
VALUES ('Desenvolvimento'),('Redes'),('Multimídia')
GO

select * from usuario
select * from equipe

INSERT INTO professor(idUsuario,idEquipe,nomeProfessor)
VALUES (1,1,'Saulo Santos'),(2,2,'Lucas Aragão')
GO

INSERT INTO tema(nomeTema)
VALUES ('React-Native'),('Infra de uma rede pequena'),('Design')
GO

INSERT INTO projeto(idProfessor,idTema,nomeProjeto,descricao,dataCriacao)
VALUES (1,1,'Estelar','Projeto desenvolvido de pequeno porte, e diversos fatores','24-09-2019'),
		(2,2,'Futuro','Projeto desenvolvido','27-09-2021')
GO

