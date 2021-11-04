
use gufi;
go

select * from tipo
select * from usuario
select * from instituicao
select * from tipoEvento
select * from presenca


select U.idUsuario, U.nomeUsuario as Usuario, T.idTipo, T.tituloTipoUsario from usuario U
inner join tipo T on U.idTipo=T.idTipo


select E.nomeEvento Evento, N.nomeFantasia Instituição, TE.tituloTipoEvento [Tipo de Evento] from evento E
inner join tipoEvento TE on TE.idTipoEvento = E.idTipoEvento
inner join instituicao N on N.idInstituicao = E.idInstituicao


select U.nomeUsuario Nome,
U.email [Email do Usuário],
E.nomeEvento Evento,
TE.tituloTipoEvento [Tipo de Evento],
I.nomeFantasia Instituição,
convert(varchar(20), E.dataEvento, 106) 'Data',
S.descricao Situação
from usuario U
inner join presenca P on U.idUsuario = P.idUsuario
inner join situacao S on P.idSituacao = S.idSituacao
inner join evento E on E.idEvento = P.idEvento
inner join tipoEvento TE on E.idTipoEvento = TE.idTipoEvento
inner join tipo T on T.idTipo = U.idTipo
join  instituicao I on I.idInstituicao = E.idInstituicao





-- delete from nometabela (deleta toda a table)
-- where id = 1 
