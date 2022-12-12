using AngEcommerceApi.Inteface;
using AngEcommerceApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngEcommerceApi.Data
{
    public class ProductRepository : IProductRepository
    {

        private readonly MyAppContext _context;
        
        public ProductRepository(MyAppContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Product>> GetProductAsync()
        {
            return await _context.Products
                .Include(p => p.ProductBrand)
                .Include(p=>p.ProductType)
                .ToListAsync();

        }

        public async Task<Product> GetProductbyIdAsync(int id)
        {
            return await _context.Products
                 .Include(p => p.ProductBrand)
                .Include(p => p.ProductType)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypeAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandAsync()
        {
            return await _context.ProductBrands.ToListAsync();
        }

       
    
    }
}
