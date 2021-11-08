
use SP_Medical_Group;
go

-- Mostrar os médicos e suas devidas especialidades
select M.idMedico, M.idClinica, M.nomeMedico as Nome , M.CRM, E.descricaoEspecialidade as Especialidade from Medico M
inner join Especialidades E on M.idEspecialidades = E.idEspecialidades

--Converteu a data de nascimento do usuário para o formato (mm-dd-yyyy) na exibição
select convert(varchar(20),dataNascimento,106) [Data do Evento] from Paciente

-- Mostrar as consultas, os pacientes e seus médicos, data da consulta e situação
select idConsulta, nomePaciente, nomeMedico, dataConsulta,descricaoSituacao from consulta
inner join Paciente p on p.idPaciente = consulta.idPaciente
inner join medico m on m.idmedico = consulta.idmedico
inner join situacao s on s.idsituacao = consulta.idsituacao


-- Mostrar a quantidade de usuários 
select COUNT (idUsuario) AS Usuario from Usuario;

select * from usuario
select * from Paciente
select * from Consulta

select * from Situacao
select * from Medico
select * from TipoUsuario
select * from Consulta
select * from Medico
select * from especialidades
select * from imagemUsuario
select * from clinica

SELECT dataNascimento as 'Data de Nascimento', DATEDIFF(YEAR, [dataNascimento], GETDATE()) AS Idade
FROM [Paciente];

select COUNT (idEspecialidades) AS EspecialidadeQ from Medico

select sum(idMedico) contagemMedicos from Medico
go

/*select count(idMedico) QuantidadeM from Medico

select idEspecialidades, count(idMedico), QuantidadeM from Medico group by idEspecialidades
having idEspecialidades = 8
go


select idEspecialidades, count(idMedico), Especialidade from Medico group by idEspecialidades
having idEspecialidades = 17
go
*/

select * FROM usuario
inner join paciente on paciente.idUsuario = usuario.idUsuario
select * FROM usuario
inner join Medico on Medico.idUsuario = usuario.idUsuario
select * FROM usuario
inner join Clinica on Clinica.idUsuario = usuario.idUsuario
