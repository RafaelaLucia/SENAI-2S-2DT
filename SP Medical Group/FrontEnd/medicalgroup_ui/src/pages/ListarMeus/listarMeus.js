import { useState, useEffect } from 'react';
import axios from 'axios';
import Header from '../../components/header/header'
import Footer from '../../components/footer/footer'


export default function ListarMeus(){
    const [ ListarMinhasConsultas, setListarMinhasConsultas ] = useState( [] );

    function buscarMinhasConsultas(){
        axios('http://localhost:5000/api/Consultas/MinhasConsultas/Paciente', {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
        .then(r => {
            if (r.status === 200) {
                // console.log(response);
                setListarMinhasConsultas( r.data );
            }
        })
        .catch( erro => console.log(erro) );
    };
    
    useEffect( buscarMinhasConsultas, [] );

    return(
        <div>
         <Header/>
         <span>Listar minhas/ Paciente</span>
    <section class="section_main_consulta">
        <div class="sec_consulta">
            <img src="./assets/img/und_med.png" alt=""/>
            <div class="sec_consulta_font">
                <h1>{'Você tem' + ListarMinhasConsultas[buscarMinhasConsultas.length-1] + 'consultas agendadas'}</h1>
                {/* console.log(ListaAlunos[ListaAlunos.length-1]); */}
                <p>Total de consultas : 3</p>
            </div>
        </div>
    </section>
    <section class="conteudo-consulta">
        <table class="section_dados_consulta">
            <tbody>
            <tr>
            {
                ListarMinhasConsultas.map( (consulta) => {
                return(
                <div id="block_consulta">
                    <td>{ Intl.DateTimeFormat("pt-BR", {
                        year: 'numeric', month: 'numeric', day: 'numeric',
                        hour: 'numeric', minute: 'numeric', hour12: true
                    }).format(new Date(consulta.dataConsulta)) }</td>
                    <td>{consulta.IdSituacao}</td>
                </div>
            )
        } )
    }
            </tr>           
            </tbody>
            </table>

        <div class="section-consulta-informacao">

        </div>
    </section>
         <Footer/>

        </div>
    )
};