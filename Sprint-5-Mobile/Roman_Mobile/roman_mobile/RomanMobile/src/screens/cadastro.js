import React, { Component } from 'react';

//Components React-Native
import {
  StyleSheet,
  Text,
  View,
  TextInput,
  TouchableOpacity,
  Alert
} from 'react-native';

//Components importados
import { KeyboardAwareScrollView } from 'react-native-keyboard-aware-scroll-view';
import RNPickerSelect from 'react-native-picker-select';
import AsyncStorage from '@react-native-async-storage/async-storage';

//Services
import api from '../services/api';

export default class Cadastro extends Component {
  constructor(props) {
    super(props);
    this.state = {

      //States
      idTema: 0,
      nomeProjeto: '',
      descricao: '',
      dataCriacao: new Date(),

    };
  }

  cadastrarProjeto = async () => {
    try {

      let projeto = {
        idTema : this.state.idTema,
        nomeProjeto : this.state.nomeProjeto,
        descricao : this.state.descricao,
        dataCriacao : this.state.dataCriacao
      };

      const token = await AsyncStorage.getItem('userToken');

      const resposta = await api.post('/Professores/cadastrar', projeto, {

        headers : {
          Authorization : 'Bearer ' + token
        }

      });



      if(resposta.status === 201){
        console.warn('foi criado !')
      }
      
    } catch (error) {
      console.warn(error)
    }

  }



  render() {
    return (
      <View style={styles.main}>

        {/* Header */}
        <View style={styles.header}>
          <Text style={styles.headerText}>Cadastrar Projeto</Text>
        </View>

        <KeyboardAwareScrollView style={styles.keyboardView}  >

          <View style={styles.boxInputs}>
            <TextInput onChangeText = {nomeProjeto => this.setState({nomeProjeto})}
              style={styles.cadastroInputs}
              placeholder="Nome projeto:"
              placeholderTextColor={'black'}

            />

            <View style={styles.cadastroInputs}>
            <RNPickerSelect
              onValueChange={idTema => this.setState({idTema})}
              items={[
                {key : 1, label: 'React-Native', value: 1 },
                {key : 2, label: 'Infra de uma rede pequena', value: 2 },
                {key : 3, label: 'Desing', value: 3 },
              ]}

              placeholder={{
                label: 'Selecione um tema...',
                value: null,

            }}
            />
            </View>


            <TextInput
              multiline
              style={styles.cadastroInputsDescricao}
              placeholder="Descricao:"
              placeholderTextColor={'black'}
              onChangeText = {descricao => this.setState({descricao})}
              value = {this.state.descricao}
            />

            <TouchableOpacity onPress = {() => this.cadastrarProjeto()} style={styles.cadastroButton}>
              <Text style={styles.cadastroButtonText}>Cadastrar</Text>
            </TouchableOpacity>
          </View>
        </KeyboardAwareScrollView>


      </View>
    )
  }
}

const styles = StyleSheet.create({

  main: {
    alignItems: 'center',
    backgroundColor: 'white',
    flex: 1
  },

  header: {
    backgroundColor: '#EFEFEF',
    width: 410,
    height: 66,
    alignItems: 'center',
    justifyContent: 'center'
  },

  headerText: {
    fontFamily: 'RedHatDisplay-Medium',
    fontSize: 30,
    color: '#444343'

  },

  boxInputs: {
    alignItems: 'center',
    justifyContent: 'space-around',
    flex: 1
  },

  cadastroInputs: {
    fontFamily: 'RedHatDisplay-Bold',
    fontSize: 21,
    width: 317,
    height: 55,
    backgroundColor: '#8FB7C6',
    borderRadius: 31,
    paddingLeft: 30,
    marginTop: 40
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
    paddingRight: 32,
    marginBottom: 30,
    marginTop: 40
  },

  cadastroButton: {
    width: 177,
    height: 61,
    backgroundColor: '#226089',
    paddingLeft: 14,
    paddingTop: 10,
  },

  cadastroButtonText: {
    fontSize: 31,
    color: 'white',
    fontFamily: 'RedHatDisplay-Bold',
  }

});