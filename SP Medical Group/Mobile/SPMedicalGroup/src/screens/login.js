import React, {Component} from 'react';
import {
  StyleSheet,
  Text,
  TouchableOpacity,
  View,
  Image,
  ImageBackground,
  TextInput,
} from 'react-native';

import AsyncStorage from '@react-native-async-storage/async-storage';

import api from '../services/api';

export default class Login extends Component {
  constructor(props) {
    super(props);
    this.state = {
      email: '',
      senha: '',
    };
  }
 
realizarLogin = async () => { 
  try {
    console.warn(this.state.email + ' ' + this.state.senha);

    const resposta = await api.post('/Login', {
      email: this.state.email, //ADM@ADM.COM
      senha: this.state.senha, //senha123
    });

    const tokenGerado = resposta.data.tokenGerado;
    await AsyncStorage.setItem('userToken', tokenGerado);
    if (resposta.status == 200) {
      this.props.navigation.navigate('Home');
    }else{
      console.warn('deu ruim :(')
    }
    console.warn(tokenGerado);
    
  } catch (error) {
    console.warn(error)
  }
};

  render() {
    return (
      <ImageBackground
        source={require('../assets/login.png')}
        style={StyleSheet.absoluteFillObject}>
        {/* retangulo roxo */}
        {/* <View style={styles.LoginArea}>
          <Text style={styles.loginText}>Login de Usuário</Text>
        </View> */}
        <View style={styles.overlay}/>
        
        <View style={styles.main}>
          <Image
            source={require('../assets/heart.png')}
            style={styles.mainImgLogin}
          />

          <TextInput
            style={styles.inputLogin}
            placeholder="Endereço de e-mail"
            placeholderTextColor="#65A7E6"
            keyboardType="email-address"
            // ENVENTO PARA FAZERMOS ALGO ENQUANTO O TEXTO MUDA
            onChangeText={email => this.setState({email})}
          />

          <TextInput
            style={styles.inputLogin}
            placeholder="Senha"
            placeholderTextColor="#65A7E6"
            keyboardType="default" //para default nao obrigatorio.
            secureTextEntry={true} //proteje a senha.
            // ENVENTO PARA FAZERMOS ALGO ENQUANTO O TEXTO MUDA
            onChangeText={senha => this.setState({senha})}
          />

          <TouchableOpacity
            style={styles.btnLogin}
            onPress={this.realizarLogin}>
            <Text style={styles.btnLoginText}>Logar</Text>
          </TouchableOpacity>
        </View>
      </ImageBackground>
    );
  }
}
const styles = StyleSheet.create({
  //antes da main
 
  // conteúdo da main
  main: {
    // flex: 1,
    //backgroundColor: '#F1F1F1', retirar pra nao ter conflito.
    justifyContent: 'center',
    alignItems: 'center',
    width: '100%',
    height: '100%',
  },

  mainImgLogin: {
    // tintColor: '#FFF', //confirmar que sera branco
    height: 100, //altura
    width: 90, //largura img nao é quadrada
    margin: 60, //espacamento em todos os lados,menos pra cima.
    marginTop: 0, // tira espacamento pra cima
  },

  inputLogin: {
    width: 300, //largura mesma do botao
    height: 54,
    marginBottom: 40, //espacamento pra baixo
    fontSize: 18,
    color: '#0E3961',
    backgroundColor: '#B2D3F2',
    borderRadius: 28,
    // borderBottomColor: '#FFF', //linha separadora
    // borderBottomWidth: 2, //espessura.
  },

  btnLoginText: {
    fontSize: 36, //aumentar um pouco
    fontFamily: '', //troca de fonte
    color: '#B2D3F2', //mesma cor identidade
    letterSpacing: 2, //espacamento entre as letras
    // textTransform: 'uppercase', //estilo maiusculo
  },
  btnLogin: {
    alignItems: 'center',
    justifyContent: 'center',
    height: 55,
    width: 229,
    backgroundColor: '#0E3961',
    borderColor: '#0E3961',
    borderWidth: 1,
    borderRadius: 15,
    shadowOffset: {height: 1, width: 1},
  },
  loginText:{
    fontSize: 36,
    color: '#FFF',
  },
  LoginArea:{
    alignItems: 'center',
    // backgroundColor: 'blue',
    justifyContent: 'center',
  }
});