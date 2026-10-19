using Microsoft.AspNetCore.Mvc;
using LHPets.Models;

namespace LHPets.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private static List<Cliente> _clientes = new List<Cliente>
        {
            new Cliente { Id = 1, Nome = "Ana Silva", Cpf = "123.456.789-00", Email = "ana@email.com" },
            new Cliente { Id = 2, Nome = "Carlos Oliveira", Cpf = "987.654.321-11", Email = "carlos@email.com" }
        };

        // GET: api/clientes
        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> Get()
        {
            return Ok(_clientes);
        }

        // POST: api/clientes
        [HttpPost]
        public ActionResult<Cliente> Post([FromBody] Cliente novoCliente)
        {
            if (novoCliente == null)
            {
                return BadRequest("Dados inválidos.");
            }

            novoCliente.Id = _clientes.Count > 0 ? _clientes.Max(c => c.Id) + 1 : 1;
            _clientes.Add(novoCliente);

            return CreatedAtAction(nameof(Get), new { id = novoCliente.Id }, novoCliente);
        }
    }
}
