import React, { Component } from 'react';
import {Alert, Image, StatusBar, StyleSheet, View} from 'react-native';
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';
const bottomTab = createBottomTabNavigator();
//Components Locais
import Home from './home'
import Perfil from './perfil';
import Listar from './listar';
import Medicos from './listarMedicos';

export default class BarraNavegacao extends Component {
    render() {
        return (
            <View style={styles.main}>
                <StatusBar
                    hidden={false}
                    backgroundColor='#226089'
                />
                <bottomTab.Navigator 
                    initialRouteName='Home'
                    screenOptions={({ route }) => ({
                        tabBarIcon: () => {
                            if (route.name === 'Home') {
                                  return(  
                                  <Image source={require('../assets/home.png')}
                                  style={styles.tabBarIcon}/>
                                  )
                            }

                            if(route.name === 'Listar'){
                                return(
                                    <Image source = {require('../assets/listar.png')}
                                    style = {styles.tabBarIcon}
                                />
                                )
                            }
                            
                            if(route.name === 'ListarMedicos'){
                                return(
                                    <Image source = {require('../assets/listar.png')}
                                    style = {styles.tabBarIcon}
                                />
                                )
                            }

                            if(route.name === 'Perfil'){
                              return(
                                <Image source = {require('../assets/perfil.png')}
                                style = {styles.tabBarIcon}
                            />
                              );
                            }
                        },
                        headerShown : false,
                        tabBarShowLabel: false,
                        tabBarActiveBackgroundColor: '#226089',
                        tabBarInactiveBackgroundColor: '#226089',
                        tabBarStyle : {height : 71},
                        tabBarHideOnKeyboard : true
                    })}
                >
                    <bottomTab.Screen name = "Listar" component = {Listar}/>
                    <bottomTab.Screen name = "Home" component = {Home}/>
                    <bottomTab.Screen name = "Perfil" component = {Perfil}/>
                </bottomTab.Navigator>
            </View>
        );
    }
};

const styles = StyleSheet.create({

    main: {
        flex: 1,
        backgroundColor: '#0E3961'
    },

    tabBarIcon: {
        width: 43,
        height: 43
    }

})