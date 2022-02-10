import React, {useState, useEffect} from "react";
import '../../assets/css/style.css';
import axios from 'axios';

export const Patrimonio = () => {
    
    // Cadastrar
    const[nomePaciente, setNomePaciente] = useState('');
    const[dataNascimento, setdataNascimento] = useState('');
    const[CPF, setCPF] = useState('');
    const[enderecoPaciente, setenderecoPaciente] = useState('');
    const[Telefone, setTelefone] = useState('');
    const[RG, setRG] = useState('');

    // Listar
    const[produtos, setProdutos] = useState([]);


    const Cadastrar = (event) => {

      event.preventDefault();
      
      var formData = new FormData();
      
      const element = document.getElementById('arquivo')
      const file = element.files[0]
      formData.append('arquivo', file, file.name)
      
      formData.append('id', 0);
      formData.append('nomePaciente', nomePaciente);
      formData.append('dataNascimento', dataNascimento);
      formData.append('CPF', CPF);
      formData.append('enderecoPaciente', enderecoPaciente);
      formData.append('Telefone', Telefone);
      formData.append('RG', RG);


      axios({
        method: "post",
        url: "https://62055c54161670001741ba0a.mockapi.io/Usuario/1/Paciente",
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
      axios.get('https://62055c54161670001741ba0a.mockapi.io/Usuario/1/Paciente')
      .then(resposta => {
        setProdutos(resposta.data);
      })
      .catch(erro => console.log(erro))
    }

    const Remover = (id) => {
      axios.delete('https://62055c54161670001741ba0a.mockapi.io/Usuario/1/Paciente'+id)
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
            <h2>Lista de Pacientes</h2>

            {produtos.map(item => 
              <div className="bloco-minhas" key={item.id}>
                <div>
                  <h4>Nome: {item.nomePaciente}</h4>
                  <span className="p-meus">Data Nascimento: {item.dataNascimento}</span>
                  <span className="p-meus">CPF: {item.CPF}</span>
                  <span className="p-meus">Endereço: {item.enderecoPaciente}</span>
                  <span className="p-meus">Telefone: {item.Telefone}</span>
                  <span className="p-meus">RG: {item.RG}</span>
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