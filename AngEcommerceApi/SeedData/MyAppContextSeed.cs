using AngEcommerceApi.Data;
using AngEcommerceApi.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace AngEcommerceApi.SeedData
{
    public class MyAppContextSeed
    {
        public static async Task SeedAsync(MyAppContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.ProductBrands.Any())
                {
                      var brandData = File.ReadAllText("./SeedData/Brand.json");
                      var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandData);

                    foreach(var item in brands)
                    {
                        context.ProductBrands.Add(item);
                        await context.SaveChangesAsync();
                    }

                }


                if (!context.ProductTypes.Any())
                {
                    var brandTypeData = File.ReadAllText("./SeedData/Types.json");
                    var Types = JsonSerializer.Deserialize<List<ProductType>>(brandTypeData);

                    foreach (var item in Types)
                    {
                        context.ProductTypes.Add(item);
                        await context.SaveChangesAsync();
                    }
                }


                if (!context.Products.Any())
                {
                    var productData = File.ReadAllText("./SeedData/Products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productData);

                    foreach (var item in products)
                    {
                        context.Products.Add(item);
                        await context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<MyAppContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
