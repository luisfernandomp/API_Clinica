using API_Pet.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Pet.Interfaces
{
    interface IRaca
    {
        Raca Cadastrar(Raca r);
        List<Raca> LerTodos();
        Raca BuscarPorId(int id);
        Raca Alterar(Raca r, int id);
        void Excluir(int id);
    }
}
