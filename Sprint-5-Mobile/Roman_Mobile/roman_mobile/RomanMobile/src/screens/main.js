import React, { Component } from 'react';

//Components React-Native
import {
    Alert,
    Image,
    StatusBar,
    StyleSheet,
    View
} from 'react-native';

import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';

//não pode usar o component direto, então temos que armazenar em uma variável.
const bottomTab = createBottomTabNavigator();

//Components Locais
import Home from './home'
import Perfil from './perfil';
import Cadastro from './cadastro';



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
                            if (route.name === 'Cadastro') {
                                  return(  
                                  
                                  <Image source={require('../../assets/pen-icon.png')}
                                  style={styles.tabBarIcon}/>

                                  )

                            }

                            if(route.name === 'Perfil'){
                                return(
                                    <Image source = {require('../../assets/user-icon.png')}
                                    style = {styles.tabBarIcon}
                                />
                                )
                            }

                            if(route.name === 'Home'){
                              return(
                                <Image source = {require('../../assets/home-icon.png')}
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
                    <bottomTab.Screen name = "Cadastro" component = {Cadastro}/>
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
        backgroundColor: '#F1F1F1'
    },

    tabBarIcon: {
        width: 43,
        height: 43
    }

})