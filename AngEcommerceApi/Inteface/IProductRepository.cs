using AngEcommerceApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngEcommerceApi.Inteface
{
    public interface IProductRepository
    {
        public Task<Product> GetProductbyIdAsync(int i);
        public Task<IReadOnlyList<Product>> GetProductAsync();

        public Task<IReadOnlyList<ProductBrand>> GetProductBrandAsync();
        
        public Task<IReadOnlyList<ProductType>> GetProductTypeAsync();
    }
}
