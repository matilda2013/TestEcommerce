using AngEcommerceApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngEcommerceApi.Data
{
    public class MyAppContext : DbContext
    {

        public MyAppContext(DbContextOptions<MyAppContext> options) : base(options)
        {


        }

        public DbSet<Product> Products { get; set; }

    }
}
