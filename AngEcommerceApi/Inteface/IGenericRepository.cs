using AngEcommerceApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngEcommerceApi.Inteface
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        public Task<T>  GetProductbyIdAsync(int i);

        public Task<IReadOnlyList<T>>  ListAllAsync();

        public Task<T> GetEntityWithSpec(ISpecification<T> spec);

        public Task<IReadOnlyList<T>> ListAllSpecAsync(ISpecification<T> spec);

    }
}
