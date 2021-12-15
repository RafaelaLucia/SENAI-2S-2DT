import { Link } from 'react-router-dom';
// import img from '../../assets/img'

import Header from "../../components/header/header";
import Footer from '../../components/footer/footer'
import icon1 from '../../assets/img/calendar.png'
import icon2 from '../../assets/img/search.png'
import icon3 from '../../assets/img/doctor.png'
import clinica from '../../assets/img/ClinicaPossarle.png'
import clinica2 from '../../assets/img/ClinicaGaspar.png'
import clinica3 from '../../assets/img/Santahelena.png'

function App() {
  return (
    <div>
   <Header/>
   <section className="banner">
        <div className="banner-information">
            <h1>SP Medical Group</h1>
            <h3>Sua Saúde e o que realmente importa</h3>
        </div>
        <div className="section-block">
            <div className="block" id="block_itself">
                <Link to="/CadastroConsulta">
                {/* <img src={icon1} alt=""/> */}
                <span className="span-clinics">Agendar Consultas</span>
                </Link>
            </div>
                <Link to="/listarMeus">
            <div className="block" id="block_itself">
                {/* <img src={icon2} alt=""/> */}
                <span>Listar Consultas</span>
            </div>
                </Link>
            <div className="block" id="block_itself">
            <Link to="/cadastrarMapa">
                <span >Cadastrar Localizações</span>
                {/* <img src={icon3} alt=""/> */}
                </Link>
            </div>
        </div>
    </section>
    <section class="clinics">
        <h2>Unidades SP Medical Group</h2>
        <div class="clinics-img">
            <img src={clinica} alt=""/>
            <img src={clinica2} alt=""/>
            <img src={clinica3} alt=""/>
        </div>
        <div>
            <button 
            className="btn_clinics" 
            >Ver Regiões de atendimento</button>
        </div>
    </section>

    <Footer/>
  </div>
  );
}

export default App;