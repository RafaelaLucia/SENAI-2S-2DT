create database roman_bd;
GO

use roman_bd;
go
CREATE TABLE tipoUsuario(
	idTipousuario TINYINT PRIMARY KEY IDENTITY,
	tituloTipoUsuario VARCHAR (100)UNIQUE NOT NULL
);
GO


CREATE TABLE usuario(
	idUsuario SMALLINT PRIMARY KEY IDENTITY,
	idTipoUsuario TINYINT FOREIGN KEY REFERENCES tipoUsuario (idTipoUsuario),
	email VARCHAR(256)NOT NULL UNIQUE,
	senha VARCHAR(15)NOT NULL
);
GO
CREATE TABLE equipe(
	idEquipe SMALLINT PRIMARY KEY IDENTITY,
	nomeEquipe VARCHAR(100)
);

CREATE TABLE professor(
	idProfessor SMALLINT PRIMARY KEY IDENTITY,
	idUsuario SMALLINT FOREIGN KEY REFERENCES usuario(idUsuario),
	idEquipe SMALLINT FOREIGN KEY REFERENCES equipe(idEquipe),
	nomeProfessor VARCHAR(100),

);
GO



CREATE TABLE tema (
	idTema SMALLINT PRIMARY KEY IDENTITY,
	nomeTema VARCHAR(100)NOT NULL,
	
);
GO


CREATE TABLE projeto(
	idProjeto INT PRIMARY KEY IDENTITY,
	idProfessor SMALLINT FOREIGN KEY REFERENCES professor (idProfessor),
	idTema SMALLINT FOREIGN KEY REFERENCES tema(idTema),
	nomeProjeto VARCHAR(120),
	descricao VARCHAR(200),
	dataCriacao DATE
);
GO
