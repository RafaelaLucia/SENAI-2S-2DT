import React, {useState, useEffect} from "react";
import '../../assets/css/style.css';
import axios from 'axios';

export const Patrimonio = () => {
    
    // Cadastrar
    const[nomeMedico, setnomeMedico] = useState('');
    const[CRM, setCRM] = useState('');
    const[idClinicaNavigation, setidClinicaNavigation] = []
    const[idUsuarioNavigation, setidUsuarioNavigation] = useState('');
    const[idEspecialidadesNavigation, setidEspecialidadesNavigation] = useState('');
    
    // Listar
    const[produtos, setProdutos] = useState([]);

    const Cadastrar = (event) => {

      event.preventDefault();
      
      var formData = new FormData();
      
      const element = document.getElementById('arquivo')
      const file = element.files[0]
      formData.append('arquivo', file, file.name)
      
      formData.append('id', 0);
      formData.append('nomeMedico', nomeMedico);
      formData.append('CRM', CRM);
      formData.append('idClinicaNavigation', idClinicaNavigation);
      formData.append('idUsuarioNavigation', idUsuarioNavigation);
      formData.append('idEspecialidadesNavigation', idEspecialidadesNavigation);
     
      axios({
        method: "post",
        url: "https://62055c54161670001741ba0a.mockapi.io/Medico",
        data: formData,
        headers: { "Content-Type": "multipart/form-data" },
      })
      .then(function (response) {
        console.log(response);
        Listar();
      })
      .catch(function (response) {
        //handle error
        console.log(response);
      });
    }

    const Listar = () => {
      axios.get('https://62055c54161670001741ba0a.mockapi.io/Medico')
      .then(resposta => {
        setProdutos(resposta.data);
      })
      .catch(erro => console.log(erro))
    }

    const Remover = (id) => {
      axios.delete('https://62055c54161670001741ba0a.mockapi.io/Medico'+id)
      .then(() => {
        Listar();
      })
      .catch(erro => console.log(erro))
    }

    

    useEffect(() => {
      Listar();      
    },[]);

    return(
        <>
        
          <main className="section_main_consulta">

      
          <section className="secao-minhas">
            <h2>Lista de Medicos</h2>
            {produtos.map(item => 
              <div className="bloco-minhas" key={item.id}>
                <div>
                  <h4>Nome: {item.nomeMedico}</h4>
                  <span className="p-meus">CRM: {item.CRM}</span>
                  <td className="p-meus">Clinica: {item.idClinicaNavigation.idClinicaNavigation}</td>
                <button className="excluir" onClick={() => Remover(item.id)}>Excluir</button>
                </div>
              </div>
            )}
 </section>
          </main>
     
        </>
    )
}

export default Patrimonio;