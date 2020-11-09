using System.Collections.Generic;

namespace FindaBeer.Services.Beers
{
    public sealed class BeersFilterDTO
    {
        /// <summary>
        /// Nome da cerveja
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Temperatura ideal
        /// </summary>
        public float? Temperature { get; set; }

        /// <summary>
        /// Teor alcoólico
        /// </summary>
        public float? AlcoholContent { get; set; }

        /// <summary>
        /// Ingredientes da cerveja
        /// </summary>
        public List<string> Ingredients { get; set; }
    }
}
