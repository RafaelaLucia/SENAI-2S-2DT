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
    const r = await api.get('/Consultas/MinhasConsultas/Medico');
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
  <View  style={styles.boxInputs}>
    <View style={styles.cadastroInputs}>

      <Text style={styles.flatItemInfo}> Consulta do dia
        {Intl.DateTimeFormat("pt-BR", {
        year: 'numeric', month: 'short', day: 'numeric'
        }).format(new Date(item.dataConsulta))}
      </Text>
      <Text style={styles.projeto}>{item.idSituacaoNavigation.descricaoSituacao}</Text>
      <Text style={styles.flatItemInfo}>Paciente: {item.idPacienteNavigation.nomePaciente}</Text>
      <Text style={styles.flatItemInfo}>{item.descricao}</Text>
    </View>
    <View style={styles.footer}> 
    </View>
  </View>

    );
  }

  const styles = StyleSheet.create({

  });