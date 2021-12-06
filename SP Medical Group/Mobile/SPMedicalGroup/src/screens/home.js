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
import api from '../services/api';

export default class Consultas extends Component {
    constructor(props) {
      super(props);
      this.state = {
        
      };
    }
    render() {
        return (
          <ImageBackground
          
            source={require('../assets/clinic.png')}
            style={StyleSheet.absoluteFillObject}>
           <View>
               <Text style={styles.loginText}>São Paulo Medical Group</Text>
            </View>
          <View style={styles.overlay}/>
          <Text style={styles.btnLoginText}></Text>
          <View style={styles.main}>
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
          fontFamily: 'Rubik-VariableFont_wght'
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
          fontSize: 30,
          fontWeight: 'bold',
          color: '#2B4761',
          marginLeft: 35,
          marginTop: 30
          
        },
        LoginArea:{
          alignItems: 'center',
          // backgroundColor: 'blue',
          justifyContent: 'center',
        },
        text:{
          fontFamily: 'Rubik-VariableFont_wght'
        }
      });