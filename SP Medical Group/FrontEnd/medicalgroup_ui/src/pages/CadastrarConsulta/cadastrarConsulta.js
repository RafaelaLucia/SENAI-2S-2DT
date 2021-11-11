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
      Situacao: '', //com o navegador nao podemos mandar boolean diretamente, entao quando mandamos 0 ou 1 o C# entende automaticamente.
      idUsuario: 0,
      idMedico: 0,

      listaConsultas: [], //listaEventos
      listaUsuarios: [], //tipoeventos
      listaMedicos: [], //instituicao
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
           idPaciente: this.state.idUsuario,
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
            <form>
            <h1>Cadastro de Consulta</h1>
            <input 
            required
            name='idUsuario'
            value={this.state.idUsuario}
            onChange={this.atualizarEstado}
            type="text" 
            placeholder="CPF do paciente"
            />

            <input 
            required
            type="text" 
            placeholder="CRM do Médico(a)"
            name="idMedico"
            value={this.state.idMedico}
            onChange={this.atualizarEstado}
        />

        <select 
        name="Situacao"
        value={this.state.Situacao}
        onChange={this.atualizarEstado}
        >
        <option value="">Selecione a Situacao</option>
        <option value="1">Livre</option>
        <option value="0">Restrito</option>
        </select>

        <input 
        required
        type="text"
        name="descricao"
        value={this.state.descricao}
        onChange={this.atualizarEstado}
        placeholder="Descrição da Consulta"
        />

        <input 
        type="datetime-local"
        value={this.state.dataConsulta}
        onChange={this.atualizarEstado}
        />

        {this.state.isLoading === true && (
        <button type="submit">Loading...</button>
        )}

        {this.state.isLoading === false && (
        <button type="submit">Cadastrar</button>
        )}

        </form>



        </div>
        <div className="main_consultaC" ></div>
        </section>

             <Footer/>
          </div>
      )
   };
   
}