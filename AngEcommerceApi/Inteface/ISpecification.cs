using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AngEcommerceApi.Inteface
{
    public interface ISpecification<T>
    {
       public  Expression<Func<T, bool>> Criteria { get; }
       public List<Expression<Func<T, object>>> Includes { get; }
    }
}
 