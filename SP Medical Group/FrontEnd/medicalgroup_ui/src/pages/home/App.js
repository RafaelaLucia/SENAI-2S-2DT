import { Link, NavLink } from 'react-router-dom';
// import img from '../../assets/img'

import Header from "../../components/header/header";
import Footer from '../../components/footer/footer'

function App() {
  return (
    <div>
   <Header/>
   <section class="banner">
        <div class="banner-information">
            <h1>SP Medical Group</h1>
            <h3>Sua Saúde e o que realmente importa</h3>
        </div>
        <div class="section-block">
            <div class="block" id="block_itself">
                <NavLink to="/CadastroConsulta">
                <img src="./assets/img/calendar.png" alt=""/>
                <span>Agendar Consultas</span>
                </NavLink>
            </div>
            <div class="block" id="block_itself">
                <img src="./assets/img/search.png" alt=""/>
                <span>Listar Consultas</span>
            </div>
            <div class="block" id="block_itself">
                <img src="./assets/img/doctor.png" alt=""/>
                <span>Encontre um Médico</span>
            </div>
        </div>
    </section>
    <section class="clinics">
        <h2>Unidades SP Medical Group</h2>
        <div class="clinics-img">
            <img src="../../assets/img/Clinica.png" alt=""/>
            <img src="./assets/img/Clinica.png" alt=""/>
            <img src="./assets/img/Clinica.png" alt=""/>
        </div>
            <button id="btn_clinics">Ver mais unidades</button>
    </section>

    <Footer/>
  </div>
  );
}

export default App;