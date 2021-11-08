import {React, Component} from "react";
import axios from 'axios'

export default class Perfil extends Component{
    constructor(props){
        super(props);
        this.state = {
         imagem64: '',
         arquivo: null

        }
    };

    upload = () => {
        const formData = new FormData();
        formData.append(
            'arquivo', //nome do arquivo que será enviado
             this.state.arquivo //valor, arquivo físico
        )
        axios.post('http://localhost:5000/api/perfils/imagem/bd', formData, {
            Headers:{
                Authorization: 'Bearer' + localStorage.getItem
                ('usuario-login')
             }
        }).catch((er) => console.log(er))
    }

    atualizaState = (event) => {
        console.log(event)
        this.setState({arquivo: event.target.files[0]})
    }

    buscarImagem = () => {
        axios('htpp://localhost:5000/api/perfils/imagem/bd', {
            Headers:{
                Authorization: 'Bearer' + localStorage.getItem
                ('usuario-login')
             }
            }).catch((er) => console.log(er))
        .then((r) => {
            if(r.status == 200){
                this.setState({imagem64: r.data})
            }
        })}

    componentDidMount(){
         this.buscarImagem()
    }

    render(){
        return(
            <div>
              <input type='file' onChange={this.atualiza}/>
              <button onClick={this.upload}>Enviar</button>
              <img src={'data:image;base64,${this.state.imagem64}'} alt="Imagem de Perfil"></img>
            </div>
        )
    }
}