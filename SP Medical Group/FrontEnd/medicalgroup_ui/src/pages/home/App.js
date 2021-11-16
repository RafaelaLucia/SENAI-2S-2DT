import { Link, NavLink } from 'react-router-dom';
// import img from '../../assets/img'

import Header from "../../components/header/header";
import Footer from '../../components/footer/footer'
import icon1 from '../../assets/img/calendar.png'
import icon2 from '../../assets/img/search.png'
import icon3 from '../../assets/img/doctor.png'
import clinica from '../../assets/img/Clinica.png'

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
                <Link to="/CadastroConsulta">
                <img src={icon1} alt=""/>
                <span>Agendar Consultas</span>
                </Link>
            </div>
                <Link to="/listarMeus">
            <div class="block" id="block_itself">
                <img src={icon2} alt=""/>
                <span>Listar Consultas</span>
            </div>
                </Link>
            <div class="block" id="block_itself">
                <img src={icon3} alt=""/>
                <span>Encontre um Médico</span>
            </div>
        </div>
    </section>
    <section class="clinics">
        <h2>Unidades SP Medical Group</h2>
        <div class="clinics-img">
            <img src={clinica} alt=""/>
            <img src={clinica} alt=""/>
            <img src={clinica} alt=""/>
        </div>
            <button id="btn_clinics">Ver mais unidades</button>
    </section>

    <Footer/>
  </div>
  );
}

export default App;