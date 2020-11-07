using FindaBeer.Services.Images;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FindaBeer.Services.Services.Beers
{
    public sealed class BeersService
    {
        private readonly IMongoCollection<Beer> beers;

        private readonly ImagesService imagesService;

        public BeersService(IConfiguration config, ImagesService imagesService)
        {
            this.imagesService = imagesService;

            var client = new MongoClient(config.GetConnectionString("FindaBeerDB"));
            var database = client.GetDatabase("FindaBeerDB");
            beers = database.GetCollection<Beer>("Beers");
        }

        public async Task<List<Beer>> Get()
        {
            return await beers.Find(s => true).ToListAsync();
        }

        public async Task<Beer> Get(string id)
        {
            return await beers.Find(s => s.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Beer> Create(Beer s)
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

            await beers.InsertOneAsync(s);
            return s;
        }

        public async Task<Beer> Update(string id, Beer s)
        {
            await beers.ReplaceOneAsync(su => su.Id == id, s);
            return s;
        }


        public async Task<bool> Remove(string id)
        {
            var result = await beers.DeleteOneAsync(su => su.Id == id);

            return result.DeletedCount > 0;
        }
    }
}
