import React from 'react';
import ReactDOM from 'react-dom';
import { Route, BrowserRouter as Router, Redirect ,Switch } from 'react-router-dom';
//Estilo
import './index.css';
//Import
import Home from './pages/home/App';
import TiposEventos from './pages/tiposEventos/TiposEventos';
import NotFound from './pages/notFound/NotFound';
import Login from './pages/login/login.js';
//Report
import reportWebVitals from './reportWebVitals';
import { parseJwt, usuarioAutenticado } from './services/auth';

const PermissaoAdm = ({ component : Component }) => (
  <Route
    render = { props => 
      usuarioAutenticado() && parseJwt().role === '1' ?
      // operador spread
      <Component {...props} /> :
      <Redirect to='login' />
    }
  />
)

const routing = (
  <Router>
    <div>
      <Switch>
        <Route exact path="/" component={Home} />
        <Route path="/tiposEventos" component={TiposEventos} />
        <Route path="/login" component={Login} />
        <Route path="/notFound" component={NotFound} /> {/* Not Found */}
        <Redirect to="/notFound" /> {/* Redireciona para Not Found caso não encontre nenhuma rota */}
      </Switch>
    </div>
  </Router>
)

ReactDOM.render(
  routing,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
