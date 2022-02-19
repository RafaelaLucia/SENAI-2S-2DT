import React, {Component} from 'react';
import {
  StyleSheet,
  Text,
  Image,
  View,
  TextInput,
  TouchableOpacity
  
} from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';
import api from '../services/api';

export default class Login extends Component {
  constructor(props) {
    super(props);
    this.state = {
      email:'',
      senha:'',

    };
  }

  realizarLogin = async () =>{
    // console.warn(this.state.email+' '+this.state.senha)

    try {
      const resposta = await api.post('/Login/login' , {
        email: this.state.email,
        senha: this.state.senha,
      });
  
      const token = resposta.data.token;
  
      await AsyncStorage.setItem('userToken', token);
  
      if (resposta.status == 200) {
       
        this.props.navigation.navigate('Main');
      }
    } catch (error) {
      console.warn(error)
    }



  }
  
  render() {
    return (
    <View style={styles.login}>
      <View style={styles.formLogin}>
      <Image
            source={require('../assets/img/logo_login.png')}
            style={styles.mainImgLogin}
          />
        
        <Text style={styles.titulo}>ROMAN</Text>
        <TextInput
            style={styles.inputLogin}
            placeholder="E-mail"
            placeholderTextColor="#A29898"
            keyboardType="email-address"    
            // ENVENTO PARA FAZERMOS ALGO ENQUANTO O TEXTO MUDA
            onChangeText={email => this.setState({email})}
          />

          <TextInput
            style={styles.inputLogin}
            placeholder="Senha"
            placeholderTextColor="#A29898"
            keyboardType="default" //para default nao obrigatorio.
            secureTextEntry={true} //proteje a senha.
            // ENVENTO PARA FAZERMOS ALGO ENQUANTO O TEXTO MUDA
            onChangeText={senha => this.setState({senha})}
          />

          <TouchableOpacity
            style={styles.btnLogin}
            onPress={this.realizarLogin}>
            <Text style={styles.btnLoginText}>LOGAR</Text>
          </TouchableOpacity>

      </View>
    </View>
    )
  }
}

const styles = StyleSheet.create({
  login:{
    justifyContent:'center',
    alignItems:'center',
    height:'100%',
    backgroundColor: '#8FB7C6'

    
  },
  formLogin:{
    justifyContent: 'space-evenly',
    alignItems: 'center',
    width: '100%',
    height: '80%',
  },


  mainImgLogin:{
    width: 107,
    height: 107,
    
  },
  titulo:{
    fontFamily:'RedHatDisplay-Medicum',
    color:'#fff' ,
    fontSize:34,
    fontWeight:'500',
   
  },  
  inputLogin:{
    width:317,
    height:55,
    backgroundColor:'#fff',
    fontSize: 18,
    borderRadius:34,
    paddingLeft:10
  },
  btnLogin:{
    backgroundColor:'#226089',
    height:61,
    width:177,
    alignItems: 'center',
    justifyContent: 'center',
    borderRadius:15
  },
  btnLoginText:{
    color:'#fff',
    fontSize:24,
    fontWeight:'500',
    textAlign:'center',
    fontFamily:'RedHatDisplay-Medium',
  }
  




});
