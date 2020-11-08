using System;
using System.Collections.Generic;
using System.Text;

namespace FindaBeer.Services.Beers
{
    public sealed class BeersFilterDTO
    {
        public string Name { get; set; }

        public float? Temperature { get; set; }

        public float? AlcoholContent { get; set; }

        public List<string> Ingredients { get; set; }
    }
}
