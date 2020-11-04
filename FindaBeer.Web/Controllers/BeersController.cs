using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindaBeer.Api.Controllers
{
    [Route("api/beers")]
    [ApiController]
    public class BeersController : ControllerBase
    {
        /// <summary>
        /// Retorna uma lista de cervejas.
        /// </summary>
        [HttpGet]
        public IEnumerable<BeerDTO> Get()
        {
            var list = new List<BeerDTO>()
            {
                new BeerDTO()
                {
                    Id = 1,
                    Name = "Antartica"
                },
                new BeerDTO()
                {
                    Id = 2,
                    Name = "Skol"
                },
                new BeerDTO()
                {
                    Id = 3,
                    Name = "Colorado"
                },
            };

            return list;
        }
    }

    public class BeerDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}