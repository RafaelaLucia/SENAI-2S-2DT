import React from 'react';
import ReactDOM from 'react-dom';
import { Route, BrowserRouter as Router, Redirect ,Switch } from 'react-router-dom';

//Estilo
//Import
import Home from './pages/home/App';
import Login from './pages/login/login';
import NotFound from './pages/notFound/notFound';
import CadastroC from './pages/CadastrarConsulta/cadastrarConsulta'
import MinhasConsultas from './pages/ListarMeus/listarMeus'
//Report
import reportWebVitals from './reportWebVitals';
import {parseJwt, usuarioLogado } from './services/auth';

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
        <Route exact path="/" component={Home} />
        <Route path="/login" component={Login} />
        <Route path="/listarMeus" component={MinhasConsultas} />
        <PermissaoAdm path="/CadastroConsulta" component={CadastroC} />
        <Route path="/notFound" component={NotFound} /> {/* Not Found */}
        <Redirect to="/notFound" /> {/* Redireciona para Not Found caso não encontre nenhuma rota */}
      </Switch>
    </div>
  </Router>
)
ReactDOM.render(routing, document.getElementById('root'));

reportWebVitals();
