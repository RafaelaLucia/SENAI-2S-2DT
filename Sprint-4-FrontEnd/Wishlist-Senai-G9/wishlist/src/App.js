import './App.css';
import logo from '../src/assets/splotch-solid 1.png'
import icon from '../src/assets/trash.ico'
import {Component} from "react";
import axios from 'axios';

class App extends Component{
  constructor(props){
      super(props);
      this.state = {
       listaDesejos: [],
       descricao: '',
       data: Date,
       idUsuario: 0,
       // tentativa desafio 2 abaixo

       idUsuarioLista: 0,

       // tentativa desafio 2 acima

       // tentativa desafio 3 abaixo

        msgErro: ''

        // tentativa desafio 2 acima
      }
  };

  buscarDesejos = () => {
    console.log('Fazer a chamada para a API')
    fetch('http://localhost:5000/api/desejo')
    .then(r => r.json()) 
    .then(data => this.setState({listaDesejos: data}) ) 
    .catch(erro => console.log(erro)) 
}

cadastrarDesejos = (desejo) => {
  desejo.preventDefault();

  fetch('http://localhost:5000/api/desejo', {
      method: 'POST', 
      body: JSON.stringify({ descricao : this.state.descricao, idUsuario: this.state.idUsuario, dataDesejo: new Date()}),
      headers :{
          "Content-Type" : "application/json"
      }
  })
  
  .then(console.log("desejo cadastrado."))
  .catch(erro => this.setState({msgErro: erro}))  //retorno do catch: tentativa desafio 3
  .then(this.buscarDesejos)
  .then(this.setState({ descricao: ''}))
}

atualizar = async (desejo) => {
  await this.setState({  
    descricao : desejo.target.value,
  })
  console.log(this.state.descricao);
 }

 atualizarId = async (desejo) => {
    await this.setState({  
      idUsuario : desejo.target.value,
    })
    console.log(this.state.idUsuario);
   }

// tentativa desafio 2 abaixo

 atualizarIdLista = async (desejo) => {
    await this.setState({  
      idUsuarioLista : desejo.target.value,
    })
    console.log(this.state.idUsuario);
   }

// tentativa desafio 2 acima

 excluirDesejo = (item) => {
  console.log('O desejo' + item.idDesejo + 'foi selecionado');
  fetch('http://localhost:5000/api/desejo/' + item.idDesejo, {
      method: 'DELETE', 
})

.then(resposta => {
  if(resposta.status === 204){
     console.log(
         'O desejo' + item.idDesejo + 'foi excluído com sucesso.'
     )
  }
})
.catch(erro => console.log(erro))
.then(this.buscarDesejos);
};

componentDidMount(){
  this.buscarDesejos()
  axios.get('http://localhost:5000/api/desejo/')
  .then(response => this.setState({listaDesejos: response.data}))
  .catch(err => { 
      this.setState({msgErro: err.message});
    })

}

  render() {
    return(
      <div>
       <header>
        <div class="ContainerGrid ContainerHeader">
            <div class="Logotipo">
                <img src={logo} alt={"star"} />
                <span>WishList</span>
            </div>
            <nav>
                <a>Home</a>
            </nav>
        </div>
    </header>
    <main>
        <section class="Banner">
            <div class="ContainerGrid ContainerBanner">
                <h1>WishList</h1>
                <span>Defina seus sonhos,
                    desejos e objetivos
                    para o futuro!</span>
            </div>
        </section>
        <section class="Cadastro">
            <div class="ContainerGrid ContainerCadastro">
                <h2>Cadastro</h2>
                <form class="FormularioCadastro" onSubmit={this.cadastrarDesejos} >
                    <div class="CamposFormulario">
                        <div class="CampoFormCadastro">
                            <label>Descrição</label>
                            <input type="text" value={ this.state.descricao} onChange={this.atualizar} />
                        </div>
                        <div class="CampoFormCadastro">
                            <label>Usuário</label>
                            <select onChange={this.atualizarId} value={this.state.idUsuario}>
                                <option value={0}>Selecione o email do usuario desejado</option>
                            {this.state.listaDesejos.map((desejo) => (
                            <option value={desejo.idUsuario}>{desejo.idUsuarioNavigation.email}</option>
                            ))}
                            </select>
                        </div>
                    </div>
                    <button class="FormSubmit" type="submit">Cadastrar</button>
 
                   
                </form>

                {/* tentativa desfio 3 abaixo */}

                { this.state.errorMessage &&
                <h3 className="error"> { this.state.errorMessage } </h3> }

                {/* tentativa desfio 3 acima */}

            </div>
        </section>
        <section class="Lista">
            <div class="ContainerLista ContainerGrid">
                <h2>Desejos</h2>

                {/* // tentativa desafio 2 abaixo */}

                <label>Usuário</label>
                            <select className="slc" onChange={this.atualizarIdLista} value={this.state.idUsuarioLista}>
                                <option value={0}>Selecione o email do usuario desejado</option>
                            {this.state.listaDesejos.map((desejo) => (
                            <option value={desejo.idUsuario}>{desejo.idUsuarioNavigation.email}</option>
                            ))}
                            </select>
                
                {/* // tentativa desafio 2 acima */}

                <table>
                    <thead>
                        <tr>
                            <th>Desejo</th>
                            <th>Sonhador</th>
                            <th>Data</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                    {
                  
  
    // .filter == tentativa desafio 2
this.state.listaDesejos.filter(d => d.idUsuario == this.state.idUsuarioLista).map((desejo) => {
  return(
    <tr key={desejo.idDesejo}> 
    <td>{(desejo.descricao)}</td>
    <td>{desejo.idUsuarioNavigation.email}</td>
    <td>{new Intl.DateTimeFormat('pt-BR', {timeZone: 'UTC'}).format(new Date(desejo.dataDesejo))}</td>
    <td><button onClick={() => this.excluirDesejo(desejo)}><img src={icon} alt={"icon"} className="icon"/></button></td>
    </tr>
 )
})
}
                    </tbody>
                </table>
            </div>
        </section>
    </main>
    <footer>
        <div class="ContainerGrid ContainerFooter">
            <div class="Logotipo">
                <span>WishList</span>
                <img src={logo} alt={"star"} />
            </div>
        </div>
    </footer>
        </div>    
  )
  }

}

export default App;
