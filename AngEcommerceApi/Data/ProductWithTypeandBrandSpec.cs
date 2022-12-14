using AngEcommerceApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngEcommerceApi.Data
{
    public class ProductWithTypeandBrandSpec : BaseSpecification<Product>
    {
        public ProductWithTypeandBrandSpec()
        {
            AddInclude(c => c.ProductType);
            AddInclude(c => c.ProductBrand);
        }

        public ProductWithTypeandBrandSpec(int id)
            :base(x => x.Id == id)
        {
            AddInclude(c => c.ProductType);
            AddInclude(c => c.ProductBrand);
        }

    }
}
