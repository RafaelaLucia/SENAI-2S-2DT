import React, {Component} from 'react';
import {FlatList, Image, StyleSheet, Text, View} from 'react-native';
import api from '../services/api';
import AsyncStorage from '@react-native-async-storage/async-storage';
import {TextInput, TouchableOpacity} from 'react-native-gesture-handler';

export default class Consultas extends Component {
  constructor(props) {
    super(props);
    this.state = {
      listaConsultas: [],
    };
  }

  buscarConsultas = async () => {
    try {
      const tokenGerado = await AsyncStorage.getItem('userToken');
      if (tokenGerado != null) {
        const resposta = await api.get('Consultas/MinhasConsultas/Paciente', {
          headers: {
            Authorization: 'Bearer ' + tokenGerado,
          },
        });

        if (resposta.status == 200) {
          console.warn(resposta);
          const dadosDaApi = resposta.data;
          this.setState({listaConsultas: dadosDaApi});
        }
      }
    } catch (error) {
      console.warn(error);
    }
  };

  medicoConsulta = async () => {
    try {
      const tokenGerado = await AsyncStorage.getItem('userToken');
      if (tokenGerado != null) {
        const resposta = await api.get('Consultas/MinhasConsultas/Medico', {
          headers: {
            Authorization: 'Bearer ' + tokenGerado,
          },
        });

        if (resposta.status == 200) {
          console.warn(resposta);
          const dadosDaApi = resposta.data;
          this.setState({listaConsultas: dadosDaApi});
        }
      }
    } catch (error) {
      console.warn(error);
    }
  };

  componentDidMount() {
    this.buscarConsultas();
    this.medicoConsulta();
  }

  render() {
    return (
      <View style={styles.main}>
        <View style={styles.mainHeader}>
          <View style={styles.mainHeaderRow}>
            <Image source = {require('../assets/undraw.png')}style = {styles.mainHeaderImg}/>
            <Text style={styles.mainHeaderText}>
              {'Consultas Paciente'}
            </Text>
          </View>
        </View>
        <View style={styles.mainBody}>
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
    <View style={styles.flatItemRow}>
      <View style={styles.flatItemContainer}>
        <Text style={styles.flatItemInfo}> Consulta do dia {Intl.DateTimeFormat("pt-BR", { year: 'numeric', month: 'numeric', day: 'numeric', hour: 'numeric', minute: 'numeric', hour12: true }).format(new Date(item.dataConsulta))}</Text>
          
        <Text style={styles.flatItemInfoC}>Consulta {item.idSituacaoNavigation.descricaoSituacao}</Text>
        <Text style={styles.flatItemInfo}>Médico: {item.idMedicoNavigation.nomeMedico}</Text>
        <Text style={styles.flatItemInfo}>Paciente: {item.idPacienteNavigation.nomePaciente}</Text>
        <Text style={styles.flatItemInfo}>Descrição: {item.descricao}</Text>
      </View>
    </View>
  );
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
    width: 400,
    justifyContent: 'center',
    alignItems: 'center',
    backgroundColor: '#2B4761',
    borderRadius: 41,
    marginTop: 19,
    marginLeft: 5,

  },
  mainHeaderRow: {
    flexDirection: 'row',
  },
  // imagem do cabeçalho
  mainHeaderImg: {
    width: 111,
    height: 82,
    marginRight: 30,
    marginTop: -12,
  },
  // texto do cabeçalho
  mainHeaderText: {
    fontSize: 18,
    letterSpacing: 2,
    fontWeight: 'bold',
    color: '#FFFF',
    marginTop: 18
  },



  // conteúdo do body
  mainBody: {
    flex: 4,
  },
  // conteúdo da lista
  mainBodyContent: {
    paddingTop: 30,
    paddingRight: 50,
    paddingLeft: 50,
  },
  // dados do evento de cada item da lista (ou seja, cada linha da lista)
  flatItemRow: {
    flexDirection: 'row',
    borderBottomWidth: 1,
    borderBottomColor: '#ccc',
    marginTop: 40,
    backgroundColor: '#65A7E6',
    width: 350,
    height: 277,
    marginLeft: -20
  },
  flatItemContainer: {
    flex: 1,
  },
  flatItemTitle: {
    fontSize: 16,
    color: '#333',
  },
  flatItemInfo: {
    fontSize: 24,
    color: '#0E3961',
    lineHeight: 22,
    padding: 10
  },
  flatItemInfoC:{
    fontSize: 24,
    color: '#FFFF',
    lineHeight: 24,
    padding: 10
  },

  flatItemImg: {
    justifyContent: 'center',
  },
  flatItemImgIcon: {
    width: 20,
    height: 20,
    // tintColor: '#B727FF',
  },
});