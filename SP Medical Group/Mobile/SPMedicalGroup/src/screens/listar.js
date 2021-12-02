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
    const r = await api.get('/Consultas/MinhasConsultas/Paciente');
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
          <Text style={styles.headerText}>Você tem X consultas agendadas</Text>
          <Text style={styles.headerText}>De um total de X</Text>
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
  <View  style={styles.boxInputs}>
    <View style={styles.cadastroInputs}>

      <Text style={styles.flatItemInfo}> Consulta do dia
        {Intl.DateTimeFormat("pt-BR", {
        year: 'numeric', month: 'short', day: 'numeric'
        }).format(new Date(item.dataConsulta))}
      </Text>
      <Text style={styles.projeto}>{item.idSituacaoNavigation.descricaoSituacao}</Text>
      <Text style={styles.flatItemInfo}>Médico: {item.idMedicoNavigation.nomeMedico}</Text>
      <Text style={styles.flatItemInfo}>{item.descricao}</Text>
    </View>
    <View style={styles.footer}> 
    </View>
  </View>

    );
  }

  const styles = StyleSheet.create({

  });