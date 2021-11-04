
use SP_Medical_Group;
go

insert into Clinica (nomeClinica, CNPJ, razaoSocial, endereco, idUsuario)
values ('Clínica Possarle','86.400.902/0001-30','SP Medical Group', 'Av. Barão Limeira, 532, São Paulo, SP', 11);
go
delete clinica
insert into Especialidades (descricaoEspecialidade)
values ('Acupuntura'),('Anestesiologia'),('Angiologia'),('Cardiologia'),('Cirurgia Cardiovascular'),('Cirurgia da Mão'),
('Cirurgia do Aparelho Digestivo'),('Cirurgia Geral'),('Cirurgia Pediátrica'),('Cirurgia Plástica'),('Cirurgia Torácica'),
('Cirurgia Vascular'),('Dermatologia'),('Radioterapia'),('Urologia'),('Pediatria'),('Psiquiatria');
go

insert into Situacao (descricaoSituacao)
values ('Realizada'),('Agendada'),('Cancelada');
go

insert into tipoUsuario (descricaoTipo)
values ('Administrador'),('Médico'),('Paciente');
go

insert into Paciente (idUsuario, nomePaciente, dataNascimento, CPF, enderecoPaciente, Telefone, RG)
values (4,'Ligia','13/10/1983','94839859000','Rua Estado de Israel 240, São Paulo, Estado de São Paulo, 04022-000','11 3456-7654','43522543-5'),
(5,'Alexandre','23/07/2001','73556944057','Av. Paulista, 1578 - Bela Vista, São Paulo - SP, 01310-200','11 98765-6543','32654345-7'),
(6,'Fernando','10/10/1978','16839338002','Av. Ibirapuera - Indianópolis, 2927,  São Paulo - SP, 04029-200','11 97208-4453','54636525-3'),
(7,'Henrique','13/10/1985','14332654765','R. Vitória, 120 - Vila Sao Jorge, Barueri - SP, 06402-030','11 3456-6543','54366362-5'),
(8,'João','27/08/1975','91305348010','R. Ver. Geraldo de Camargo, 66 - Santa Luzia, Ribeirão Pires - SP, 09405-380','11 7656-6377','53254444-1'),
(9,'Bruno','21/03/1972','79799299004','Alameda dos Arapanés, 945 - Indianópolis, São Paulo - SP, 04524-001','11 95436-8769','54566266-7'),
(10,'Mariana','05/03/2018','13771913039','R Sao Antonio, 232 - Vila Universal, Barueri - SP, 06407-140',null,'54566266-8');
go

insert into Medico (idClinica, idUsuario, idEspecialidades, nomeMedico, CRM)
values (1,1,2,'Ricardo Lemos','54356-SP'),(1,2,17,'Roberto Possarle','53452-SP'),(1,3,16,'Helena Strada','65463-SP');
go
delete Medico


insert into Consulta (idSituacao, idPaciente, idMedico, dataConsulta, descricao)
values (1,7,3, '20/01/2020 15:00:00','exame de rotina'),(3,2,2, '06/01/2020 10:00:00','consulta semanal'),(1,3,2, '07/02/2020 11:00:00','consulta semanal'),(1,2,2, '06/02/2018 10:00:00', 'exame diagnóstico'),
(3,4,1, '07/02/2019 11:00:45','consulta semanal'),(2,7,3, '08/03/2020 15:00:00','exame de rotina'),(2,4,1, '09/03/2020 11:00:45','exame diagnóstico');
go
delete Consulta

insert into Usuario (idTipo, enderecoEmail, senha)
values (2, 'ricardo.lemos@spmedicalgroup.com.br','ricardo1'),(2,'roberto.possarle@spmedicalgroup.com.br','robert12'),
(2,'helena.souza@spmedicalgroup.com.br','helen123'),(3, 'ligia@gmail.com','ligia111'),(3, 'alexandre@gmail.com','alexan32'),
(3,'fernando@gmail.com','fer123'),(3,'henrique@gmail.com','henry123'),(3,'joao@hotmail.com','joao1234'),
(3,'bruno@gmail.com','bruno123'),(3,'mariana@outlook.com','marizi18'),(1,'clinicaPossarleADM','adm123');
go
delete Usuario



