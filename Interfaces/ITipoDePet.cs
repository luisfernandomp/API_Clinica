using API_Pet.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Pet.Interfaces
{
    interface ITipoDePet
    {
        TipoDePet Cadastrar(TipoDePet pet);
        List<TipoDePet> LerTodos();
        TipoDePet BuscarPorId(int id);
        TipoDePet Alterar(TipoDePet pet, int id);
        void Excluir(int id);
    }
}
