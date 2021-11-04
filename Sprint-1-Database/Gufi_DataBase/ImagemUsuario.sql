create table imagemUsuario (
id int primary key identity(1,1),
idUsuario int not null unique foreign key references usuario(idUsuario),
binario varbinary(max) not null,
mimeType varchar(30) not null,
nomeArquivo varchar(250) not null, 
data_inclusao datetime default getdate() null

);
go

select * from imagemUsuario

