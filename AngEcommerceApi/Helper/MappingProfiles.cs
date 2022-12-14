using AngEcommerceApi.Model;
using AngEcommerceApi.Model.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngEcommerceApi.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDTO>()
               .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
               .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
               .ForMember(d => d.PictureUrl , o => o.MapFrom<ProductUrlResolver>());
        }
    }
}
