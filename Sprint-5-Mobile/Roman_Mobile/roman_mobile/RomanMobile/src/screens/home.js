import React, {Component} from 'react';
import {FlatList, StyleSheet, Text, View} from 'react-native';

import api from '../services/api';

export default class Home extends Component {
  constructor(props) {
    super(props);
    this.state = {
      listaProjetos: [],
    };
  }

  buscarProjetos = async () => {
    try {
       // debugger;
    const r = await api.get('/Usuarios/Projetos/Listar');
    //  console.warn(r);
    const dadosDaApi = r.data;
    this.setState({listaProjetos: dadosDaApi});
    } catch (error) {
      console.warn(error);
    }
  }

  componentDidMount() {
    this.buscarProjetos();
  }
  
  render() {
    return (
      <View style={styles.main}>
      {/* Cabeçalho - Header */}
      <View style={styles.header}>
          <Text style={styles.headerText}>Projetos</Text>
        </View>

      {/* Corpo - Body */}
      <View  style={styles.boxInputs}>
        <FlatList
          contentContainerStyle={styles.mainBodyContent}
          data={this.state.listaProjetos}
          keyExtractor={item => item.idProjeto}
          renderItem={this.renderItem}
        />
      </View>
    </View>
  );
}

renderItem = ({item}) => (
  // <Text style={{ fontSize: 20, color: 'red' }}>{item.nomeEvento}</Text>

  <View  style={styles.boxInputs}>
    <View style={styles.cadastroInputs}>
      <Text style={styles.projeto}>Projeto {item.nomeProjeto}</Text>
      <Text style={styles.flatItemInfo}>Descrição: {item.descricao}</Text>
      <Text style={styles.flatItemInfo}>Professor: {item.idProfessorNavigation.nomeProfessor}</Text>
      <Text style={styles.flatItemInfo}>
      Tema: {item.idTemaNavigation.nomeTema}
      </Text>
      <Text style={styles.flatItemInfo}>
        {Intl.DateTimeFormat("pt-BR", {
                          year: 'numeric', month: 'short', day: 'numeric',
                          hour: 'numeric', minute: 'numeric', hour12: true 
                      }).format(new Date(item.dataCriacao))}
      </Text>
    </View>

    <View style={styles.footer}>
     
    </View>
  </View>

    );
  }

  const styles = StyleSheet.create({

    main: {
      alignItems : 'center',
      backgroundColor: 'white',
      flex : 1
    },
    projeto: {
       color: 'white',
       fontWeight: 'bold'
    },
    flatItemInfo: {
       padding: 3
    },
  
    header: {
      backgroundColor: '#DAD6D6',
      width: 410,
      height: 69,
      alignItems: 'center',
      justifyContent: 'center'
    },
  
    headerText: {
      fontFamily: 'RedHatDisplay-Regular',
      fontSize: 30,
      color : '#444343'
  
    },
  
    boxInputs : {
      alignItems : 'center',
      justifyContent : 'space-around',
      flex : 1
    },
  
    cadastroInputs: {
      fontFamily: 'RedHatDisplay-Regular',
      fontSize: 16,
      width: 321,
      height: 140,
      backgroundColor: '#8FB7C6',
      borderRadius: 31,
      // paddingLeft: 30,
      // paddingTop: 1,s
      marginTop:35,
      alignItems: 'center',
      justifyContent: 'center'
    },
  
    cadastroInputsDescricao: {
      fontFamily: 'RedHatDisplay-Regular',
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
     fontFamily: 'RedHatDisplay-Regular',
    } 
  
  });