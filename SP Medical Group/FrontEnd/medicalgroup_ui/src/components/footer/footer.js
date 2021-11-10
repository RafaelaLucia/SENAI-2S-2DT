import React from 'react'
import { NavLink } from 'react-router-dom'
import Logo from '../../assets/img/logo.png'
import home from '../../pages/home/App'

 export default function Hedaer(){
 return (
<footer className="footer">
        <div className="footer_link">

            <span>Agendar Consultas</span>
            <span>Listar Consultas</span>
            <span>Encontre um Médico</span>
            <span>Especialidades</span>
        </div>

        <div className="footer_termo">    
            <p>Termos de Uso e política de privacidade</p>
            <p id="p_termo"> Copyright © 2021 São Paulo Medical Group. Todos os direitos reservados.</p>
        </div>

        <div className="footer-comunicacao">
            <p>Canais de comunicação</p>
            <div className="footer-comunicacao-img">
                <img src="assets/img/image 11.png" alt=""/>
                <img id="face" src="assets/img/image 12.png" alt=""/>
                <img src="assets/img/image 13.png" alt=""/>
            </div>
        </div>
    </footer>

 )
 };