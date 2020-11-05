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

        public BeersService(IConfiguration config)
        {
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
