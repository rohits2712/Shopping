using Amazon.Runtime.Internal.Util;
using MongoDB.Bson;
using MongoDB.Driver;
using Shopping.API.Models;

namespace Shopping.API.Data
{
    public class ProductContext
    {
        public ProductContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["DatabaseSettings:ConnectionString"]);
            var database = client.GetDatabase(configuration["DatabaseSettings:DatabaseName"]);
            Products = database.GetCollection<Product>(configuration["DatabaseSettings:CollectionName"]);
            var collectionNames = GetAllCollectionNamesAsync(database).Result;
            SeedData(Products);
        }

        private void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)  productCollection.InsertMany(GetPreConfiguredProducts());
        }

        public IMongoCollection<Product> Products { get; }

        public static IEnumerable<Product> GetPreConfiguredProducts()
        {
            return new List<Product> { 
                new Product(){ Category = "SMART PHONE", Name= "Iphone"},
                new Product(){ Category = "SMART PHONE", Name= "Iphone12"}
            };

        }

        private async Task<List<string>> GetAllCollectionNamesAsync(IMongoDatabase database)
        {
            var filter = new BsonDocument(); // Empty filter to match all collections
            var collectionCursor = await database.ListCollectionNamesAsync();
            return await collectionCursor.ToListAsync();
        }

    }
}
