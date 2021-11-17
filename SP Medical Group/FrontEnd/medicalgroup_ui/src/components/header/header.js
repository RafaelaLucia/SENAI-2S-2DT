import React from 'react'
import { NavLink } from 'react-router-dom'
import Logo from '../../assets/img/logo.png'

 export default function Hedaer(){
 return (
<header className="header">
<NavLink to="/">
<img src={Logo} alt="Logo Sp Medical-Group" className="logo-img" />
</NavLink>
<div className="navigation-header">
<span>Especialidades</span>
<span>Encontre um Médico</span>
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