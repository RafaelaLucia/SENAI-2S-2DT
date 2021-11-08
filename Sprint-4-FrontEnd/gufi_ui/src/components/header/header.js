import React from 'react'
import { NavLink } from 'react-router-dom'
import logo from '../../assets/img/logo.png'
import home from '../../pages/home/App'

 export default function Hedaer(){
 
      return(
        <header className="cabecalhoPrincipal">
        <div className="container">
          <NavLink to="/"><a><img src={logo} alt="Logo da Gufi"></img></a></NavLink>
  
          <nav className="cabecalhoPrincipal-nav">
            <a onClick={home}>Home</a>
            <NavLink to="/tiposEventos"><a>Eventos</a></NavLink>
            <a>Contato</a>
            <NavLink to="/login"><a className="cabecalhoPrincipal-nav-login" >Login</a></NavLink>
            
          </nav>
        </div>
      </header>
      )
}