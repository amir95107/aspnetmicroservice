using Catalog.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configuraion)
        {
            var client = new MongoClient(configuraion.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuraion.GetValue<string>("DatabaseSettings:DatabaseName"));

            Products = database.GetCollection<Product>(configuraion.GetValue<string>("DatabaseSettings:CollectionName"));
            //CatalogContextSeed.SeedData(Products);
        }
        public IMongoCollection<Product> Products { get; }
    }
}
