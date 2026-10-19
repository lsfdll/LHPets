using Microsoft.AspNetCore.Mvc;
using LHPets.Models;

namespace LHPets.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private static List<Pet> _pets = new List<Pet>
        {
            new Pet { Id = 1, Nome = "Thor", Especie = "Cão", Raca = "Golden Retriever", ClienteId = 1 },
            new Pet { Id = 2, Nome = "Miau", Especie = "Gato", Raca = "Siamês", ClienteId = 1 },
            new Pet { Id = 3, Nome = "Bob", Especie = "Cão", Raca = "Poodle", ClienteId = 2 }
        };

        // GET: api/pets
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {
            return Ok(_pets);
        }

        // POST: api/pets
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet novoPet)
        {
            if (novoPet == null)
            {
                return BadRequest("Dados inválidos.");
            }

            novoPet.Id = _pets.Count > 0 ? _pets.Max(p => p.Id) + 1 : 1;
            _pets.Add(novoPet);

            return CreatedAtAction(nameof(Get), new { id = novoPet.Id }, novoPet);
        }

        // GET: api/pets/cliente/{clienteId}
        [HttpGet("cliente/{clienteId}")]
        public ActionResult<IEnumerable<Pet>> GetByClienteId(int clienteId)
        {
            var petsDoCliente = _pets.Where(p => p.ClienteId == clienteId).ToList();

            if (!petsDoCliente.Any())
            {
                return NotFound($"Nenhum pet encontrado para o ClienteId {clienteId}.");
            }

            return Ok(petsDoCliente);
        }
    }
}
