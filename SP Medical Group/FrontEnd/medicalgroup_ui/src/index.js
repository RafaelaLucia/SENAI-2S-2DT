import React from 'react';
import ReactDOM from 'react-dom';
import { Route, BrowserRouter as Router, Redirect ,Switch } from 'react-router-dom';

//Estilo
//Import
import Home from './pages/home/App';
import Login from './pages/login/login';
import NotFound from './pages/notFound/notFound';
import Cadastro from './pages/CadastrarConsulta/cadastrarConsulta'
import pacientes from './pages/ListarPacientes/lista.jsx'
// import MinhasConsultas from './pages/ListarMeus/listarMeus'
// import MedicosConsulta from './pages/ListarMeusMedicos/listarMeusMedicos'
import ADMConsulta from './pages/listarMeusADM/listarMeusADM'
import Listagem from './pages/Listagem/listagem'
//Report
import reportWebVitals from './reportWebVitals';
import {parseJwt, usuarioLogado } from './services/auth';
import cadastrarMapa from './pages/mapas/cadastroMapa'

const PermissaoAdm = ({ component: Component }) => (
  <Route
    render={(props) =>
      usuarioLogado() && parseJwt().role === '1' ? (
        // operador spread
        <Component {...props} />
      ) : (
        <Redirect to="CadastroConsulta" />
      )
    }
  />
);

const routing = (
  <Router>
    <div>
      <Switch>
        <Route exact path="/" component={pacientes} />
        <Route path="/login" component={Login} />
        <PermissaoAdm path="/cadastrarMapa" component={cadastrarMapa} />
        <Route path="/listarMeusADM" component={ADMConsulta} />
        {/* <Route path="/listarMeus" component={MinhasConsultas} />
        <Route path="/listarMeusMedicos" component={MedicosConsulta} /> */}
        <Route path="/listarMinhas" component={Listagem} />
        <PermissaoAdm path="/CadastroConsulta" component={Cadastro} />
        <Route path="/notFound" component={NotFound} /> {/* Not Found */}
        <Redirect to="/notFound" /> {/* Redireciona para Not Found caso não encontre nenhuma rota */}
      </Switch>
    </div>
  </Router>
)
ReactDOM.render(routing, document.getElementById('root'));

reportWebVitals();
