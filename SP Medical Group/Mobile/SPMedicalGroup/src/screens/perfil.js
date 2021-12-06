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
      // nome: '',
      listaUsuarios: [],
      email: '',
      base64: '',
    };
  }

  buscarDadosStorage = async () => {
    try {
      const valorToken = await AsyncStorage.getItem('userToken');
      //ja recebe string e converte para objeto.
      console.warn(jwtDecode(valorToken));

      if (valorToken != null) {
        // this.setState({nome: jwtDecode(valorToken).name});
        this.setState({email: jwtDecode(valorToken).email});
        // this.setState({email: jwtDecode(valorToken).email});
      }
    } catch (error) {
      console.warn(error);
    }
  };

  // buscarConsultas = async () => {
  //   try {
  //     const resposta = await api.get('/Consultas/MinhasConsultas/Paciente');
  //     // console.warn(resposta);
  //     const dadosDaApi = resposta.data;
  //     this.setState({listaConsultas: dadosDaApi});
  //   } catch (error) {
  //     console.warn(error)
  //   }
  // };

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
    const tokenGerado = await AsyncStorage.getItem('userToken');

    api.get('Perfis/imagem/bd', {
        headers: {
          Authorization: 'Bearer ' + tokenGerado,
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
     
       {/* Corpo - Body - Section */}
        <View style={styles.mainBody}>
          <View style={styles.mainBodyInfo}>
              <Image
                source={require('../assets/profile.png')}
                style={styles.mainBodyImg}
              />
            {/* <Text style={styles.mainBodyText}>{this.state.nome}</Text> */}
            <Text style={styles.mainBodyText}>{this.state.email}</Text>
          </View>

          <TouchableOpacity
            style={styles.btnLogout}
            onPress={this.realizarLogout}>
            <Text style={styles.btnLogoutText}>{'Sair'.toUpperCase()}</Text>
          </TouchableOpacity>
        </View>
      </View>
    );
  }
}

const styles = StyleSheet.create({
  // conteúdo da main
  main: {
    flex: 1,
    backgroundColor: '#F1F1F1',
  },
  // cabeçalho
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
    marginTop: 30
  },
  // informações do usuário
  mainBodyInfo: {
    alignItems: 'center',
  },
  mainBodyImg: {
    // backgroundColor: '#ccc',
    width: 179.9,
    height: 179,
    // borderRadius: 50,
    marginBottom: 50,
  },
  mainBodyText: {
    color: '#999',
    fontSize: 16,
    marginBottom: 20,
  },
  // botão de logout
  btnLogout: {
    alignItems: 'center',
    justifyContent: 'center',
    height: 33,
    width: 111,
    borderTopWidth: 1,
    borderColor: '#ccc',
    marginBottom: 50,
    backgroundColor: '#81DF99'
  },
  // texto do botão
  btnLogoutText: {
    fontSize: 16,
    fontFamily: 'Open Sans',
    color: '#FFFFFF',
  },
});