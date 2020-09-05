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
    public class RacaController : ControllerBase
    {
        RacaRepository repo = new RacaRepository();

        // GET: api/Raca
        [HttpGet]
        public List<Raca> Get()
        {
            return repo.LerTodos();
        }

        // GET: api/Raca/5
        [HttpGet("{id}", Name = "GetRaca")]
        public Raca Get(int id)
        {
            return repo.BuscarPorId(id);
        }

        // POST: api/Raca
        [HttpPost]
        public Raca Post([FromBody] Raca r)
        {
            return repo.Cadastrar(r);

        }

        // PUT: api/Raca/5
        [HttpPut("{id}")]
        public Raca Put(int id, [FromBody] Raca r)
        {
            return repo.Alterar(r, id);

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            repo.Excluir(id);
            return "Excluído com sucesso!";
        }
    }
}
