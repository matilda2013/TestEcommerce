using AngEcommerceApi.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngEcommerceApi.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        void IEntityTypeConfiguration<Product>.Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(150);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(200);
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
            builder.Property(p => p.PictureUrl).IsRequired();
            builder.HasOne(b => b.ProductBrand).WithMany().HasForeignKey(p => p.ProductBrandId);
            builder.HasOne(c => c.ProductType).WithMany().HasForeignKey(p => p.ProductTypeId);
        }
    }
}
