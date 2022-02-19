using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wishlist_webAPI.Domains;

namespace wishlist_webAPI.Interfaces
{
    interface IDesejoRepository
    {
        List<Desejo> Listar();
        void Cadastrar(Desejo novoDesejo);
        void Deletar(short id);
    }
}
