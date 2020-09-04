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
    public class ClinicasController : ControllerBase
    {
        ClinicasRepository repo = new ClinicasRepository();

        // GET: api/Clinicas
        [HttpGet]
        public List<Clinicas> Get()
        {
            return repo.LerTodos();
        }

        // GET: api/Clinicas/5
        [HttpGet("{id}", Name = "GetClinicas")]
        public Clinicas Get(int id)
        {
            return repo.BuscarPorId(id);
        }

        // POST: api/Clinicas
        [HttpPost]
        public Clinicas Post([FromBody] Clinicas c)
        {
            return repo.Cadastrar(c);
        }

        // PUT: api/Clinicas/5
        [HttpPut("{id}")]
        public Clinicas Put(int id, [FromBody] Clinicas c)
        {
            return repo.Alterar(c, id);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            repo.Excluir(id);
            return "Clínica excluído com sucesso!";
        }
    }
}
