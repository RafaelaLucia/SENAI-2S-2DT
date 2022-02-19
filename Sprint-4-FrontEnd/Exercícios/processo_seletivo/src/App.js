import './App.css';
import {Component} from "react";

class App extends Component{
  constructor(props){
      super(props);
      this.state = {
       listaDeRepositorios: [],
       nomeRepositorio: '',
       limit : ''
      // idTipoEventoAlterado : 0
      }
  };

  buscarRepositorio = (repositorio) => {
  repositorio.preventDefault();
  console.log('Fazer a chamada para a API');
  fetch('https://api.github.com/users/' + this.state.nomeRepositorio + '/repos?per_page=10&sort=login-date')
  .then(r => r.json())
  .then(data => this.setState({listaDeRepositorios: data }))
  .catch(erro => console.log(erro))
  
  }

 atualizar = async (repositorio) => {
  await this.setState({  
    nomeRepositorio : repositorio.target.value   
  })
  console.log(this.state.nomeRepositorio);
 }

  render() {
    return (
      <div>
        <main>
          <section className='section'>
            <h1 className='bw'>Procurar Repositórios de um Usuário do github</h1>
            <p>Insira o nome de um usuário do github e visualize os seus últimos 10 repositórios</p>
            <form onSubmit={this.buscarRepositorio}>
              <input type="text" value={this.state.nomeRepositorio} onChange={this.atualizar} placeholder='Nome do Usuário do GitHub'/>
                <button type="submit" onClick={this.buscarRepositorio}>Procurar</button> 
            </form>
            </section>
            <section>
            <h2 className='h2'>Lista de Repositórios</h2>
            <table className='table'>
              <thead>
               <tr className = 'teste'>
                <th>ID</th>
                <th>Nome</th>
                <th>Descrição</th>
                <th>Data da Criação</th>
                <th>Tamanho</th>
                 </tr>
              </thead>
              <tbody className='tbody'>
                {this.state.listaDeRepositorios.map((repositorio) => {
                    return(
                       <tr key={repositorio.id}> 
                       <td id='id'>{repositorio.id}</td>
                       <td>{repositorio.name}</td>
                       <td>{repositorio.description}</td>
                       <td>{repositorio.created_at}</td>
                       <td>{repositorio.size}</td>
                       </tr>
                       
                      ) 
                  })
                 
                }
              </tbody>
            </table>
          </section>
        </main>
      </div>
    )
  }
}

export default App;