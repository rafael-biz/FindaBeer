using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FindaBeer.Services.Beers
{
    public sealed class BeerDTO
    {
        /// <summary>
        /// Código identificador
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// Nome da cerveja
        /// </summary>
        [BsonElement("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Descrição
        /// </summary>
        [BsonElement("Description")]
        public string Description { get; set; }

        /// <summary>
        /// Cor da cerveja
        /// </summary>
        [BsonElement("Color")]
        public float Color { get; set; }

        /// <summary>
        /// Teor alcoólico
        /// </summary>
        [BsonElement("AlcoholContent")]
        public float AlcoholContent { get; set; }

        /// <summary>
        /// Harmonização da cerveja
        /// </summary>
        [BsonElement("Pairings")]
        public string Pairings { get; set; }

        /// <summary>
        /// Ingredientes da cerveja
        /// </summary>
        [BsonElement("Ingredients")]
        public List<string> Ingredients { get; set; }

        /// <summary>
        /// Temperatura mínima ideal
        /// </summary>
        [BsonElement("TemperatureMin")]
        public int TemperatureMin { get; set; }

        /// <summary>
        /// Temperatura máxima ideal
        /// </summary>
        [BsonElement("TemperatureMax")]
        public int TemperatureMax { get; set; }

        /// <summary>
        /// Imagem padrão da cerveja.
        /// </summary>
        [BsonElement("DefaultImage")]
        public string DefaultImage { get; set; }

        /// <summary>
        /// Campo apenas de leitura com a imagem da cerveja no tamanho 300x600px.
        /// </summary>
        [BsonElement("LargeImage")]
        public string LargeImage { get; set; }

        /// <summary>
        /// Campo apenas de leitura com a imagem da cerveja no tamanho 90x180px.
        /// </summary>
        [BsonElement("Thumbnail")]
        public string Thumbnail { get; set; }
    }
}
