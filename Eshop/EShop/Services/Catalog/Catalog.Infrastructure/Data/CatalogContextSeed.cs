using Catalog.Core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Data
{
    public static class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            var checkProducts = productCollection.Find(b => true).Any();
            string path = "../Catalog.Infrastructure/Data/SeedData/products.json";

            if (!checkProducts)
            {
                var productsData = File.ReadAllText(path);
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                if (products != null)
                {
                    foreach (var pro in products)
                    {
                        productCollection.InsertOneAsync(pro);
                    }
                }
            }
        }
    }
}
