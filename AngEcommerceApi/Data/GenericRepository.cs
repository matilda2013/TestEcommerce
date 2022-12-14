using AngEcommerceApi.Inteface;
using AngEcommerceApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngEcommerceApi.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {

        private readonly MyAppContext _context;

        public GenericRepository(MyAppContext context)
        {
            _context = context;
        }

        public async Task<T> GetProductbyIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync( id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }


        public async Task<IReadOnlyList<T>> ListAllSpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }
    }
}
