import React from 'react'
import { NavLink } from 'react-router-dom'
import Logo from '../../assets/img/logo.png'
import home from '../../pages/home/App'

 export default function Hedaer(){
 return (
<header className="header">
<NavLink to="/">
<img src={Logo} alt="Logo Sp Medical-Group" className="logo-img" />
</NavLink>
<div className="navigation-header">
<span>Especialidades</span>
<span>Encontre um Médico</span>

<NavLink className="nav-header"  to={ 
 
}>
<span>Listar minhas Consultas</span>
</NavLink>
</div>

<NavLink to='/login'>
<button 

className="button-header"
>Logar
</button>
</NavLink>
</header>
 ) 
}