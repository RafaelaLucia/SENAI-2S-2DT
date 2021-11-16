import { useState, useEffect } from 'react';
import axios from 'axios';
import Header from '../../components/header/header'
import Footer from '../../components/footer/footer'
import '../../assets/css/style.css';
import foto from '../../assets/img/und_med.png'


export default function ListarMeus(){
    const [ ListarMinhasConsultas, setListarMinhasConsultas ] = useState( [] );

    function buscarMinhasConsultas(){
        axios('http://localhost:5000/api/Consultas/MinhasConsultas/Medico', {
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
    <section className="section_main_consulta">
        <div className="sec_consulta">
            <img src={foto} alt=""/>
            <div className="sec_consulta_font">
                    <p>
                     Total de Consultas:
                     {
               ListarMinhasConsultas.map( (consulta) => {
                   return(
                    <div>
                       {consulta.idConsulta}
                    </div>
                   )
        } )                                
    }
                    </p>
        </div>
        </div>
    </section>
   <section className="secao-minhas">
       <table>
           <tbody>

           {
               ListarMinhasConsultas.map( (consulta) => {
                   return(
                    <tr key={consulta.idConsulta} className="bloco-minhas">
                    <td className="data-meus">Consulta do dia { Intl.DateTimeFormat("pt-BR", {
                    year: 'numeric', month: 'numeric', day: 'numeric',
                    }).format(new Date(consulta.dataConsulta)) }</td>
                    {/* <td className="span-meus">{consulta.idSituacaoNavigation.descricaoSituacao}</td> */}
                   <img src="assets/img/star.png" alt=""/>
                   <td className="p-meus">Médico: {consulta.idMedicoNavigation.nomeMedico}</td>
                   <td className="p-meus">Paciente: {consulta.idPacienteNavigation.nomePaciente}</td>
                   <td className="p-meus"> às { Intl.DateTimeFormat("pt-BR", {
                    hour: 'numeric', minute: 'numeric', hour12: true
                    }).format(new Date(consulta.dataConsulta)) }</td>

                   <td className="p-meus">Descrição: {consulta.descricao}</td>
                   </tr>
                   )
        } )                                
    }
    </tbody>
       </table>
    </section>
         <Footer/>

        </div>
    )
};