import notFound from '../../assets/img/NFound.png'

function NotFound() {
    return (
      <div className="n-encontrado-main">
          <h1>404 - Página não encontrada</h1>
          <img src={notFound}></img>
      </div>
    );
  }
  
  export default NotFound;