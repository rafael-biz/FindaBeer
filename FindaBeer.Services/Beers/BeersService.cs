using FindaBeer.Services.Images;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindaBeer.Services.Beers
{
    public sealed class BeersService
    {
        private readonly IMongoCollection<BeerDTO> beers;

        private readonly ImagesService imagesService;

        public BeersService(IConfiguration config, ImagesService imagesService)
        {
            this.imagesService = imagesService;

            var client = new MongoClient(config.GetConnectionString("FindaBeerDB"));
            var database = client.GetDatabase("FindaBeerDB");
            beers = database.GetCollection<BeerDTO>("Beers");
        }

        public async Task<List<BeerDTO>> GetList(BeersFilterDTO filterDTO)
        {
            if (filterDTO == null)
            {
                return await beers.Find(s => true).ToListAsync();
            }
            else
            {
                var builder = Builders<BeerDTO>.Filter;

                var filter = builder.Empty;

                if (!string.IsNullOrEmpty(filterDTO.Name))
                {
                    filter &= builder.Regex(e => e.Name, new BsonRegularExpression(filterDTO.Name, "i"));
                }

                if (filterDTO.Temperature.HasValue)
                {
                    filter &= builder.Lte(e => e.TemperatureMin, filterDTO.Temperature.Value);
                    filter &= builder.Gte(e => e.TemperatureMax, filterDTO.Temperature.Value);
                }

                if (filterDTO.AlcoholContent.HasValue)
                {
                    filter &= builder.Gte(e => e.AlcoholContent, filterDTO.AlcoholContent.Value - 0.01f);
                    filter &= builder.Lte(e => e.AlcoholContent, filterDTO.AlcoholContent.Value + 0.01f);
                }

                if (filterDTO.Ingredients != null && filterDTO.Ingredients.Count > 0)
                {
                    var ingredients = filterDTO.Ingredients.Where(i => i != null).Select(i => i.ToLowerInvariant());

                    filter &= builder.All(e => e.Ingredients, ingredients);
                }

                return await beers.Find(filter).ToListAsync();
            }
        }

        public async Task<BeerDTO> Get(string id)
        {
            return await beers.Find(s => s.Id == id).FirstOrDefaultAsync();
        }

        public async Task<BeerDTO> Create(BeerDTO s)
        {
            ResizeImage(s);

            await beers.InsertOneAsync(s);
            return s;
        }

        public async Task<BeerDTO> Update(string id, BeerDTO s)
        {
            ResizeImage(s);

            await beers.ReplaceOneAsync(su => su.Id == id, s);
            return s;
        }

        private void ResizeImage(BeerDTO s)
        {
            if (!string.IsNullOrEmpty(s.DefaultImage))
            {
                using (var image = imagesService.FromBase64(s.DefaultImage))
                {
                    using (var croped = imagesService.CropCenter(image, 300, 600))
                    {
                        s.LargeImage = imagesService.ToBase64(croped);
                    }

                    using (var croped = imagesService.CropCenter(image, 90, 180))
                    {
                        s.Thumbnail = imagesService.ToBase64(croped);
                    }
                }
            }
        }

        public async Task<bool> Remove(string id)
        {
            var result = await beers.DeleteOneAsync(su => su.Id == id);

            return result.DeletedCount > 0;
        }
    }
}
