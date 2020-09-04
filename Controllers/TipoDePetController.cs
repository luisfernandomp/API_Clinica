using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Pet.Domains;
using API_Pet.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Pet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDePetController : ControllerBase
    {
        TipoDePetRepository repo = new TipoDePetRepository();

        // GET: api/TipoDePet
        [HttpGet]
        public List<TipoDePet> Get()
        {
            return repo.LerTodos();
        }

        // GET: api/TipoDePet/5
        [HttpGet("{id}", Name = "GetTipoDePet")]
        public TipoDePet Get(int id)
        {
            return repo.BuscarPorId(id);
        }

        // POST: api/TipoDePet
        [HttpPost]
        public TipoDePet Post([FromBody] TipoDePet pet)
        {
            return repo.Cadastrar(pet);
        }

        // PUT: api/TipoDePet/5
        [HttpPut("{id}")]
        public TipoDePet Put(int id, [FromBody] TipoDePet pet)
        {
            return repo.Alterar(pet, id);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            repo.Excluir(id);
            return "Tipo de pet excluído com sucesso!";
        }
    }
}
