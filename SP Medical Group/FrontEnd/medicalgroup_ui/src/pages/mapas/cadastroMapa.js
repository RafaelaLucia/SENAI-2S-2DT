import { React, Component } from 'react';
import axios from 'axios';
import Header from '../../components/header/header'
import Footer from '../../components/footer/footer'


export default class cadastrarConsulta extends Component {
  constructor(props) {
    super(props);
    this.state = {
      latitude: '',
      longitude: '',
      cadastrou: false,
      Mtela: '',

      listaMapa: [], 
      isLoading: false,

    };
  }

  buscarMapa = () => {
      axios('http://localhost:5000/api/localizacoes', {
      }).then((r) => {
          if(r.status === 200){
              this.setState({listaMapa: r.data});
          }
      }).catch((error) => console.log(error));
  }

   atualizarEstado = (item) => {
       this.setState({[item.target.name] : item.target.value});
   };

   componentDidMount(){
       this.buscarMapa();
   }

   cadastrarMapa = (item) => {
       item.preventDefault();
       this.setState({isLoading: true});

       let localizacao = {
           latitude: this.state.latitude,
           longitude: this.state.longitude,
       };
       axios.post('http://localhost:5000/api/localizacoes', localizacao, {
       }).then((r) => {
           if(r.status === 201){
               console.log('Evento Cadastrado eba :D');
               this.setState({Mtela: 'Localização cadastrada com sucesso!!', isLoading: false});
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
        <div className="mapa_consultaC">
        <h1>Cadastro de Localizações</h1>
        <form className="formu-cadastro" onSubmit={this.cadastrarMapa}>
              <div
                style={{
                  display: 'flex',
                  flexDirection: 'column',
                  width: '20vw',
                }}
              >
                <input
                className="cadastro_input"
                  required
                  type="text"
                  name="latitude"
                  value={this.state.latitude}
                  onChange={this.atualizarEstado}
                  placeholder="latitude"
                />

                <input
                className="cadastro_input"
                  required
                  type="text"
                  name="longitude"
                  value={this.state.longitude}
                  onChange={this.atualizarEstado}
                  placeholder="longitude"
                />

                {this.state.isLoading && (
                  <button className="botao-cada-consulta" type="submit" disabled>
                    Loading...{' '}
                  </button>
                )}

                {this.state.isLoading === false && (
                  <button className="botao-cada-consulta" id="cadastrado" type="submit">Cadastrar</button>
                )}

                   <p id="M-stilo">{this.state.Mtela}</p>
              </div>
            </form>
        </div>
        
        <div className="main_MapaC" ></div>
        </section>

             <Footer/>
          </div>
      )
   };
   
}