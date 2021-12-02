import React, {Component} from 'react';
import { StyleSheet, Text, View, Image, TouchableOpacity, PendingView,} from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';
import jwtDecode from 'jwt-decode';
import api from '../services/api';

export default class Perfil extends Component {
  constructor(props) {
    super(props);
    this.state = {
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
      .get('/Perfis/imagem/bd', {
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
        {/* <View >
          <Image style={styles.imgPerfil}
          source = {require('../../assets/user-perfil.png')}
          ></Image>
        </View> */}
        {/* Corpo - Body - Section */}
        <View style={styles.mainBody}>
          <View style={styles.mainBodyInfo}>
            {/*  */}
            {/* <TouchableOpacity
              onPress={() => this.props.navigation.navigate('Camera')}>
            </TouchableOpacity> */}

            {/* <Text style={styles.mainBodyText}>{this.state.nomeProfessor}</Text> */}
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
 
});