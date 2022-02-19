import React, {Component} from 'react';
import {
  StyleSheet,
  Text,
  View,
  Image,
  TouchableOpacity,
  PendingView,
} from 'react-native';

import AsyncStorage from '@react-native-async-storage/async-storage';
import jwtDecode from 'jwt-decode';
import api from '../services/api';

export default class Perfil extends Component {
  constructor(props) {
    super(props);
    this.state = {
      nomeProfessor: 'Teste',
      email: 'Teste@teste.com',
      base64: '',
    };
  }

  buscarDadosStorage = async () => {
    try {
      const valorToken = await AsyncStorage.getItem('userToken');
      //ja recebe string e converte para objeto.
      console.warn(jwtDecode(valorToken));

      if (valorToken != null) {
        this.setState({nomeProfessor: jwtDecode(valorToken).name});
        this.setState({email: jwtDecode(valorToken).email});
      }
    } catch (error) {
      console.warn(error);
    }
  };

  componentDidMount() {
    this.buscarDadosStorage();
    this.consultaImgPerfil();
  }

  realizarLogout = async () => {
    //vamos remover o armazenamento local.
    try {
      await AsyncStorage.removeItem('userToken');
      this.props.navigation.navigate('Login'); //tem que ser mesmo nome.
    } catch (error) {
      console.warn(error);
    }
  };

  consultaImgPerfil = async () => {
    const token = await AsyncStorage.getItem('userToken');

    api
      .get('/perfils/imagem/bd', {
        headers: {
          Authorization: 'Bearer ' + token,
        },
      })
      .then(resposta => {
        if (resposta.status === 200) {
          this.setState({base64: resposta.data});
        }
      })
      .catch(error => console.warn(error));
  };

  render() {
    return (
      <View style={styles.main}>
        {/* Cabeçalho - Header */}
        <View style={styles.header}>
          <Text style={styles.headerText}>Perfil</Text>
        </View>
        
        <View >
          <Image style={styles.imgPerfil}
          source = {require('../../assets/user-perfil.png')}
          ></Image>
        </View>

        {/* Corpo - Body - Section */}
        <View style={styles.mainBody}>
          <View style={styles.mainBodyInfo}>
            {/*  */}
            <TouchableOpacity
              onPress={() => this.props.navigation.navigate('Camera')}>
            </TouchableOpacity>

            <Text style={styles.mainBodyText}>{this.state.nomeProfessor}</Text>
            <Text style={styles.mainBodyText}>{this.state.email}</Text>
          </View>

          <TouchableOpacity
            style={styles.btnLogout}
            onPress={this.realizarLogout}>
            <Text style={styles.btnLogoutText}>Sair</Text>
          </TouchableOpacity>
        </View>

      </View>
    );
  }
}

const styles = StyleSheet.create({
  // conteúdo da main
 
  main: {
    alignItems : 'center',
    backgroundColor: 'white',
    flex : 1
  },


  header: {
    backgroundColor: '#DAD6D6',
    width: 410,
    height: 66,
    alignItems: 'center',
    justifyContent: 'center'
  },

  headerText: {
    fontFamily: 'RedHatDisplay-Medium',
    fontSize: 30,
    color : '#444343'

  },

  boxInputs : {
    alignItems : 'center',
    justifyContent : 'space-around',
    flex : 1
  },

  cadastroInputs: {
    fontFamily: 'RedHatDisplay-Bold',
    fontSize: 21,
    width: 321,
    height: 96,
    backgroundColor: '#8FB7C6',
    borderRadius: 31,
    paddingLeft: 30,
    paddingTop: 1,
    marginTop:35
  },

  cadastroInputsDescricao: {
    fontFamily: 'RedHatDisplay-Bold',
    fontSize: 21,
    width: 317,
    height: 151.04,
    backgroundColor: '#8FB7C6',
    borderRadius: 31,
    textAlignVertical: 'top',
    paddingLeft: 32,
    paddingRight: 32
  },

  cadastroButton: {
    width: 177,
    height: 61,
    backgroundColor : '#226089',
    paddingLeft : 14,
    paddingTop : 10,
  },

  cadastroButtonText : {
   fontSize : 31,
   color : 'white',
   fontFamily: 'RedHatDisplay-Bold',
  },
  // botão de logout
  btnLogout: {
    alignItems: 'center',
    justifyContent: 'center',
    height: 80,
    width: 240,
    borderTopWidth: 1,
    borderColor: '#ccc',
    marginBottom: 50,
  },
  // texto do botão
  btnLogoutText: {
    fontSize: 23,
    fontFamily: 'Open Sans',
    color: '#4592AF',
  },
  footer: {
    backgroundColor: '#226089',
    height: 85
  },
  imgPerfil: {
    marginTop: 40
  },
  mainHeader: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
  },
  mainHeaderRow: {
    flexDirection: 'row',
  },
  // imagem do cabeçalho
  mainHeaderImg: {
    width: 22,
    height: 22,
    tintColor: '#ccc',
    marginRight: -5,
    marginTop: -12,
  },
  // texto do cabeçalho
  mainHeaderText: {
    fontSize: 16,
    letterSpacing: 5,
    color: '#999',
    fontFamily: 'Open Sans',
  },
  // linha de separação do cabeçalho
  mainHeaderLine: {
    width: 220,
    paddingTop: 10,
    borderBottomColor: '#999',
    borderBottomWidth: 1,
  },

  // conteúdo do body
  mainBody: {
    flex: 4,
    alignItems: 'center',
    justifyContent: 'space-between',
  },
  // informações do usuário
  mainBodyInfo: {
    alignItems: 'center',
    marginTop: 30
  },
  mainBodyImg: {
    backgroundColor: '#ccc',
    width: 100,
    height: 100,
    borderRadius: 50,
    marginBottom: 50,
  },
  mainBodyText: {
    color: '#000000',
    fontSize: 21,
    marginBottom: 20,
  }
});