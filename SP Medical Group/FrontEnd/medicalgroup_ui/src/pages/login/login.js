import { Component } from 'react';
import axios from 'axios';
import { parseJwt, usuarioLogado } from '../../services/auth';
import { Link } from 'react-router-dom';
import Header from '../../components/header/header'
import Footer from '../../components/footer/footer'

import '../../assets/css/style.css';


export default class Login extends Component {
    constructor(props) {
        super(props);
        this.state = {
            email: 'clinicaPossarleADM',
            senha: 'adm123',
            erroM: '',
            isLoading: false
        };
    };

    Logar = (event) => {
       event.preventDefault();
       this.setState({erroM: '', isLoading: true});
       axios.post('http://localhost:5000/api/Login',{
           email: this.state.email,
           senha: this.state.senha
       })

       .then(answ => {
           if(answ.status === 200){
               localStorage.setItem('usuario-login', '');
               this.setState({isLoading: false});
               let base64 = localStorage.getItem('usuario-login').split('.')[1];
               console.log(base64);
               console.log(this.props);
               if(parseJwt().role === '1'){
                   this.props.history.push('/');
                   console.log('tá logando' + usuarioLogado())
               }else{
                   this.props.history.push('/')
               }
           }
       }).catch(() => {
           this.setState({erroM: 'E-mail e/ou senha inválidos!!', isLoading: false})
       })
    };
    atualizarEstado = (item) => {
        this.setState({[item.target.name] : item.target.value})
    };

    render() {
        return (
        <div>
       <Header/>

<section>
        <div className="login_block">
            <div className="img-block"></div>
            <div className="block-ad">

                <h1>Login de Usuário</h1>
                <form onSubmit={this.Logar}> 

                <div className="login-section">
                    <input
                     name="email"
                     value={this.state.email}
                     id="inp-login" 
                     type="text"
                     onChange={this.atualizarEstado}
                     placeholder="Endereço de E-mail"
                     />
                    <input 
                    type="password"
                    name="senha"
                    placeholder="Senha"
                    value={this.state.senha}
                    onChange={this.atualizarEstado}
                    />

                    <a href="">Esqueceu a Senha?</a>
                </div>

                <p id="erroM-stilo">{this.state.erroM}</p>

                <div className="login-block-button">     
                {
                this.state.isLoading === true &&
                <button type="submit" disabled className="login-btn" id="btn__login">
                Loading...
                </button>
                }

                {
                    this.state.isLoading === false &&
                    <button 
                    className="login-btn" id="btn__login"
                    type="submit"
                    disabled={ this.state.email === '' || this.state.senha === '' ? 'none' : '' }>
                Login
                </button>
                }

                </div>
                </form>
                <div className="login_register">
                        <span>Não tem uma conta?</span>
                        <a href="cadastro.html">Cadastre-se</a>
                    </div>
                </div>
        </div>
</section>

<Footer/>
        </div>
        )
    }

}