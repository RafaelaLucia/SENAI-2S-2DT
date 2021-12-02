import React, {Component} from 'react';
import {FlatList, StyleSheet, Text, TouchableOpacity, View} from 'react-native';
import api from '../services/api';

export default class Home extends Component {
  constructor(props) {
    super(props);
    this.state = {
      listaConsultas: [],
    };
  }

  buscarConsultas = async () => {
    try {
    const r = await api.get('/Usuarios/Projetos/Listar');
    //  console.warn(r);
    const dadosDaApi = await r.data;
    this.setState({listaConsultas: dadosDaApi});
    } catch (error) {
      console.warn(error);
    }
  }

  componentDidMount() {
    this.buscarConsultas();
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
          data={this.state.listaConsultas}
          keyExtractor={item => item.idConsulta}
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
        year: 'numeric', month: 'short', day: 'numeric'
        }).format(new Date(item.dataCriacao))}
      </Text>
    </View>
    <View style={styles.footer}> 
    </View>
  </View>

    );
  }

  const styles = StyleSheet.create({

  });