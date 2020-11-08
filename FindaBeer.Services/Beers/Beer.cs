using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FindaBeer.Services.Services.Beers
{
    public sealed class Beer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonElement("Color")]
        public float Color { get; set; }

        [BsonElement("AlcoholContent")]
        public float AlcoholContent { get; set; }

        [BsonElement("Pairings")]
        public string Pairings { get; set; }

        [BsonElement("Ingredients")]
        public List<string> Ingredients { get; set; }

        [BsonElement("TemperatureMin")]
        public int TemperatureMin { get; set; }

        [BsonElement("TemperatureMax")]
        public int TemperatureMax { get; set; }

        [BsonElement("DefaultImage")]
        public string DefaultImage { get; set; }

        [BsonElement("LargeImage")]
        public string LargeImage { get; set; }

        [BsonElement("Thumbnail")]
        public string Thumbnail { get; set; }
    }
}
