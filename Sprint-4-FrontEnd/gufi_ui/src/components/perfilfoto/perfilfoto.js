import {React, Component} from "react";
import axios from 'axios'

export default class PerfilFoto extends Component{
    constructor(props){
        super(props);
        this.state = {
         imagem64: '',
        }
    };
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
            <div></div>
        )
    }

}