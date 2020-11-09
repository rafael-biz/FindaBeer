using FindaBeer.Services.Beers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindaBeer.Api.Controllers
{
    [Route("api/beers")]
    [ApiController]
    public class BeersController : ControllerBase
    {
        private readonly BeersService service;

        public BeersController(BeersService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Retorna uma lista de cervejas.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<List<BeerDTO>>> Get()
        {
            return await service.GetList(null);
        }

        /// <summary>
        /// Retorna uma lista de cervejas de acordo com as opções do filtro.
        /// </summary>
        [HttpPost("filter")]
        public async Task<ActionResult<List<BeerDTO>>> Get(BeersFilterDTO filter)
        {
            return await service.GetList(filter);
        }

        /// <summary>
        /// Retorna uma cerveja.
        /// </summary>
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<BeerDTO>> Get(string id)
        {
            var s = await service.Get(id);
            if (s == null)
            {
                return NotFound();
            }

            return s;
        }

        /// <summary>
        /// Adiciona uma cerveja.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<BeerDTO>> Create([FromBody] BeerDTO s)
        {
            await service.Create(s);
            return CreatedAtRoute("Get", new { id = s.Id.ToString() }, s);
        }

        /// <summary>
        /// Edita uma cerveja.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult<BeerDTO>> Put(string id, [FromBody] BeerDTO su)
        {
            var s = await service.Get(id);
            if (s == null)
            {
                return NotFound();
            }
            su.Id = s.Id;

            await service.Update(id, su);
            return CreatedAtRoute("Get", new { id = su.Id.ToString() }, su);
        }

        /// <summary>
        /// Remove uma cerveja.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult<BeerDTO>> Delete(string id)
        {
            if (await service.Remove(id))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}