import React, {Component} from 'react';
import { StyleSheet, Text, Image, View, TextInput, TouchableOpacity} from 'react-native';
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
    try {
      const resposta = await api.post('/Login' , {
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
 
});