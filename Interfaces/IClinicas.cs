using API_Pet.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Pet.Interfaces
{
    interface IClinicas
    {
        Clinicas Cadastrar(Clinicas c);
        List<Clinicas> LerTodos();
        Clinicas BuscarPorId(int id);
        Clinicas Alterar(Clinicas c, int id);
        void Excluir(int id);
    }
}
