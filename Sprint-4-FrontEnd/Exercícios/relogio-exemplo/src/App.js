import React from 'react';
import './App.css';

//define um componente funcional chamado data formatada
//retorna um subtítulo(h2) com o valor da hora formatada
function DataFormatada(props){
    return <h2>Horário atual: {props.date.toLocaleTimeString()}</h2> 
}

// componenta da classe
//define a classe clock
class Clock extends React.Component{
  constructor(props){
    super(props);
    this.state = { //atribuindo ao estado(state) uma propriedade com seu valor inicial
      date: new Date(), //define a propriedade date pegando a data e hora atual
    };
  };

  thick(){
   this.setState({
     date : new Date()
   })
  };

  onClickHandler = () => {
    clearInterval(this.timerId); //antigo
    clearInterval(this.y); //novo
    console.log('Relógio x pausado')
  };

  onClickReset = () => {
    this.y = setInterval( () => { //novo
      this.thick()
    }, 1000)
    console.log('Relógio retomado!')
    console.log('Agora eu sou o relógio y')
  };


  //preencher a lista de eventos this.state.listaEventos:o que eu quiser manipular já vai estar dentro do state
  // ciclo de vida que ocorre quando o componente Clock é inserido na árvore DOM, ou seja, o ciclo
  // de vida de montagem/nascimento  
  //toda vez que setinverval e invocada ela tem retorno e pode retornar um id 
  componentDidMount(){
    this.timerId = setInterval( () => { //antigo
      this.thick()
    }, 1000)
  };

  // ciclo de vida que ocorre quando o comportamento clock é removido da árvore Dom
  //ou seja, o ciclo de vida de desmontagem/morte
  //quando o componente for desmontado, a função clearInterval limpa o relogio criado pela funcao setInterval
  componentWillUnmount(){
    //limpar a memoria que estava sendo ocupado com esse relógio
    clearInterval(this.timerId);
  }

  // renderiza o conteudo do retorno na tela
  render(){
    return(
      <div>
      <h1 id='relogio'>Relógio</h1>
      <DataFormatada date={this.state.date} />
      <div className='botoes'>
      <button id='botao' onClick={this.onClickHandler}>Pausar</button>
      <button id='botao2' onClick={this.onClickReset}>Retomar</button>
      </div>
      </div>
    )
  }
}

//componente funcional
function App() {
  return (
    <div className="App">
      <header className="App-header">
      <Clock />
      </header>
    </div>
  );
}

export default App;
