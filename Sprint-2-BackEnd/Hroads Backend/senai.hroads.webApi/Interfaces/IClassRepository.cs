using senai.hroads.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Interfaces
{
    interface IClassRepository
    {
        List<Class> Listar(); //Listar todas as classes
        Class BuscarPorId(int idClasse); //Buscar por uma classe atráves do idClasse
        void Cadastrar(Class novaClasse); //Cadastrar uma nova classe
        void Atualizar(int idClasse, Class classeAtualizada); // Atualiza as informações de uma classe já existente
        void Deletar(int idClasse); //Deletar uma classe existente através do id
        List<Class> ListarComPersonagens(); // Listar as classes e seus personagens respectivos


    }
}
