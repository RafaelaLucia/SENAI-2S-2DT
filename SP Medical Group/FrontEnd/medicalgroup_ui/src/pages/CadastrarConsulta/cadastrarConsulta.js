import { React, Component } from 'react';
import axios from 'axios';

import Header from '../../components/header/header'
import Footer from '../../components/footer/footer'


export default class cadastrarConsulta extends Component {
  constructor(props) {
    super(props);
    this.state = {
      descricao: '',
      dataConsulta: new Date(), // inicialmente vai ser do tipo date, inicia com a data e hora atual.
      idSituacao: '', //com o navegador nao podemos mandar boolean diretamente, entao quando mandamos 0 ou 1 o C# entende automaticamente.
      idPaciente: 0,
      idMedico: 0,
      cadastrou: false,

      listaConsultas: [], //listaEventos
      listaUsuarios: [], //tipoeventos
      listaMedicos: [], //instituicao
      listaSituacoes: [],
      isLoading: false,

    };
  }

  buscarPacientes = () => {
      axios('http://localhost:5000/api/Pacientes', {
          headers: {
              Authorization: 'Bearer' + localStorage.getItem('usuario-login'),
          },
      }).then((r) => {
          if(r.status === 200){
              this.setState({listaUsuarios: r.data});
              console.log(this.state.listaUsuarios);
          }
      }).catch((error) => console.log(error));
  }

  buscarMedicos = () => {
      axios('http://localhost:5000/api/Medicos', {
          headers: {
              Authorization: 'Bearer' + localStorage.getItem('usuario-login'),
          },
      }).then((r) => {
          if(r.status === 200){
              this.setState({listaMedicos: r.data});
              console.log(this.state.listaMedicos);
          }
      }).catch((error) => console.log(error));
  }

   buscarConsultas = () => {
       axios('http://localhost:5000/api/Consultas').then((r) => {
           if(r.status === 200){
               this.setState({listaConsultas: r.data});
               console.log(this.state.listaUsuarios);
           }
       }).catch((error) => console.log(error));
   }

  
   buscarSituacao = () => {
    axios('http://localhost:5000/api/Situacoes').then((r) => {
        if(r.status === 200){
            this.setState({listaSituacoes: r.data});
            console.log(this.state.listaSituacoes);
        }
    }).catch((error) => console.log(error));
}

   atualizarEstado = (item) => {
       this.setState({[item.target.name] : item.target.value});
   };

   componentDidMount(){
       console.log('começar :)');
       this.buscarPacientes();
       this.buscarMedicos();
       this.buscarConsultas();
   }

   cadastrarConsulta = (item) => {
       item.preventDefault();
       this.setState({isLoading: true});


       let consulta = {
           idPaciente: this.state.idPaciente,
           idMedico: this.state.idMedico,
           Situacao: parseInt(this.state.idSituacao),
           descricao: this.state.descricao,
           dataConsulta: new Date(this.state.dataConsulta)
       };
       axios.post('http://localhost:5000/api/Consultas/Cadastrar', consulta, {
           headers:{
               Authorization: 'Bearer' + localStorage.getItem('usuario-login'),
           },
       }).then((r) => {
           if(r.status === 201){
               console.log('Evento Cadastrado eba :D');
               this.setState({isLoading: false});
           }
       }).catch((error) => {
           console.log("deu ruim")
           console.log(error);
           this.setState({isLoading: false});
        }).then(this.buscarConsultas);
   };

   render() {
      return(
          <div>
             <Header/>

        <section className="section_cadastroC">
        <div className="conteudo_consultaC">
        <h1>Cadastro de Consulta</h1>
        <form className="formu-cadastro" onSubmit={this.cadastrarConsulta}>
              <div
                style={{
                  display: 'flex',
                  flexDirection: 'column',
                  width: '20vw',
                }}
              >
                 <select
                   className="cadastro_input"
                  name="idPaciente"
                  value={this.state.idPaciente}
                  onChange={this.atualizarEstado}
                >
                  <option value="0">Selecione o Paciente</option>

                  {this.state.listaUsuarios.map((tema) => {
                    return (
                      <option key={tema.idPaciente} value={tema.idPaciente}>
                        {tema.nomePaciente}
                      </option>
                    );
                  })}
                </select>

                <select
                  className="cadastro_input"
                  name="idMedico"
                  value={this.state.idMedico}
                  onChange={this.atualizarEstado}
                >
                  <option value="0">Selecione o Médico</option>

                  {this.state.listaMedicos.map((tema) => {
                    return (
                      <option key={tema.idMedico} value={tema.idMedico}>
                        {tema.nomeMedico}
                      </option>
                    );
                  })}
                </select>

                <select
                   className="cadastro_input"
                  name="idSituacao"
                  value={this.state.idSituacao}
                  onChange={this.atualizarEstado}
                >
                  <option value="0">Selecione a Situação</option>

                  {this.state.listaSituacoes.map((tema) => {
                    return (
                      <option key={tema.idSituacao} value={tema.idSituacao}>{tema.descricaoSituacao}</option>
                  );
                  })}
                </select> 

                <input
                className="cadastro_input"
                  required
                  type="text"
                  name="descricao"
                  value={this.state.descricao}
                  onChange={this.atualizarEstado}
                  placeholder="Descrição da Consulta"
                />

                <input
                  className="cadastro_input"
                  type="date"
                  name="dataConsulta"
                  value={this.dataConsulta}
                  onChange={this.atualizarEstado}
                />

                {this.state.isLoading && (
                  <button className="botao-cada-consulta" type="submit" disabled>
                    Loading...{' '}
                  </button>
                )}

                {this.state.isLoading === false && (
                  <button className="botao-cada-consulta" id="cadastrado" type="submit">Cadastrar</button>
                )}
              </div>
            </form>
        </div>
        <div className="main_consultaC" ></div>
        </section>

             <Footer/>
          </div>
      )
   };
   
}