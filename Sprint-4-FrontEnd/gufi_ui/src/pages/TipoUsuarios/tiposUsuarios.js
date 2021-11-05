import React, {useState, useEffect} from 'react';
import axios from 'axios';
import { func } from 'prop-types';

export default function TiposUsuarios(){
    //Estrutura de declaração de estado usando o Hook UseState
    //Const = [nomeDoState, funçãoAtualiza] = useState(valorInicial);
   const [ listaTiposUsuarios, setListaTiposUsuarios ] = useState([]);
   const [ titulo, setTitulo ] = useState('');
   const [ isLoading, setIsLoading ] = useState(false);

   //Função responsável por fazer a requisição e trazer a lista de tipos de usuários
   function buscarTiposUsuarios(){
        console.log('fazer a chamada para a API');
        //Fazer a chamada para a API usando o axios
        axios('http://localhost:5000/api/tiposusuarios', {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        }).then(r => {
            //Caso a resposta da requisição tenha um status code igual a 200 (OK)
            if(r.status === 200){
                //Atualiza o estado listaTiposUsuarios com os dados do corpo da resposta
                setListaTiposUsuarios(r.data)
            }
        }).catch(
            //Caso ocorra algum erro, exibir no console do navegador com este erro
            er => console.log(er)
        );
         
        /*Estrutura do Hooke useEffect: 
          useEffect (efeito, causa)
          useEffect({o que vai ser feito}, {o que será escutado})
          desta forma,
        */
        useEffect(buscarTiposUsuarios,[]);

        //Função responsável por fazer a requisição que cadastra um novo tipo de usuário
        function cadastrarTipoUsuario(evento){
            //evita o comportamento padrão do navegador
            evento.preventDefault();
            //Definir que uma requisição está em andamento
            setIsLoading(true);
            if(listaTiposUsuarios){
                /*verificar se existe na lista algum tipo de usuário igual ao que está sendo
                passado pelo usuário */
            }
            //Faz a chamada para a API
            axios.post('http://localhost:5000/api/tiposusuarios', {
                tituloTipoUsuario : titulo
            }, {
                headers : {
                    'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
                }
            }).then(r => {
                //Se o status code da resposta da requisição for igual a 201:
                if(r.status === 201){
                    //Exibir a mensagem no console do navegador
                    console.log('Tipo de usuário cadastrado :D');
                    //Atualizar a lista de tipos de usuário automaticamente,
                    buscarTiposUsuarios();
                    //Reseta o valor do state título,
                    setTitulo('');
                    //E volta o valor do estado isLoading para falso
                    setIsLoading(false);
                }
            })
            // caso ocorra algum erro, exibe no console do navegador este erro
            // e volta o valor do state isLoading para false
            .catch(erro => console.log(erro), setInterval(() => {
                setIsLoading( false )
            }, 5000));
        };
    
        // exibe no console o valor do state titulo a cada alteração feita pelo usuário
        console.log(titulo);

   return(
     <div>
         <main>
             <section>
                 <h2>Lista Tipos de usuários</h2>
                 <div>
                     <table style={{borderCollapse: 'separate', borderSpacing : 30}}>
                         <thead>
                             <tr>
                                 <td>Ids</td>
                                 <td>Titulo</td>
                             </tr>
                         </thead>
                         <tbody>
                             {
                                 listaTiposUsuarios.map((tipoUsuario) => {
                                     return(
                                         <tr key={tipoUsuario.idTipoUsuario}>
                                             <td>{tipoUsuario.idTipoUsuario}</td>
                                             <td>{tipoUsuario.tituloTipoUsuario}</td>
                                         </tr>
                                     )
                                 })
                             }
                         </tbody>
                     </table>
                 </div>
             </section>
             <section>
                 <h2>Cadastro de Tipo de Usuário</h2>
                 <p>O tipo de usuário {titulo} está sendo cadastrado</p>
                 <form onSubmit={cadastrarTipoUsuario}>
                     <div>
                         <input
                           type="text"
                           value={titulo}
                           onChange={(campo) => setTitulo(campo.target.value)}
                           placeholder="Título do tipo de usuário"
                         />
                         {
                             isLoading === false &&
                             <button type='submit'>Cadastrar</button>
                         }
                         {
                             isLoading === true &&
                             <button type='submit' disabled>Carregando...</button>
                         }
                        {/* {
                            outra forma:
                            isLoading === false ? (
                            <button type="submit">Cadastrar</button>
                            ) : ( 
                            <button type="submit" disabled>Carregando...</button>
                            )
                        }  */}
                     </div>
                 </form>
             </section>
         </main>
   </div>
    )
}

};