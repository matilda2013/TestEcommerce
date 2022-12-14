using AngEcommerceApi.Data;
using AngEcommerceApi.Inteface;
using AngEcommerceApi.Model;
using AngEcommerceApi.Model.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngEcommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //private readonly IProductRepository _repo;
        //public ProductController(IProductRepository repo)
        //{
        //    _repo = repo;
        //}

        private readonly IGenericRepository<Product> _Productrepo;
        private readonly IGenericRepository<ProductType> _ProdTyperepo;
        private readonly IGenericRepository<ProductBrand> _ProdBrandrepo;
        private readonly IMapper _mapper;
       public ProductController(IGenericRepository<Product> Productrepo, IGenericRepository<ProductType> ProdTyperepo, 
            IGenericRepository<ProductBrand> ProdBrandrepo, IMapper mapper)
        {
            _Productrepo = Productrepo;
            _ProdTyperepo = ProdTyperepo;
            _ProdBrandrepo = ProdBrandrepo;
            _mapper = mapper;
        }
        [HttpGet]

        public async Task<ActionResult<IReadOnlyList<ProductDTO>>> GetProducts()
        {
            var spec = new ProductWithTypeandBrandSpec();
            var product = await _Productrepo.ListAllSpecAsync(spec);
            return Ok(_mapper.Map<IReadOnlyList<Product>,  IReadOnlyList<ProductDTO>>(product));
            
            
            //return product.Select(product => new ProductDTO
            //{
            //    Id = product.Id,
            //    Name = product.Name,
            //    Description = product.Description,
            //    PictureUrl = product.PictureUrl,
            //    Price = product.Price,
            //    ProductBrand = product.ProductBrand.Name,
            //    ProductType = product.ProductType.Name
            //}).ToList();

            // var products = await _Productrepo.ListAllAsync();//.GetProductAsync();
            // return Ok(products);
        }

        [HttpGet("Types")]
        public async Task<ActionResult<List<ProductType>>> GetProductTypes()
        {
            var products = await _ProdTyperepo.ListAllAsync();// GetProductTypeAsync();
            return Ok(products);
        }

        [HttpGet("Brands")]
        public async Task<ActionResult<List<Product>>> GetProductBrands()
        {
            var products = await _ProdBrandrepo.ListAllAsync();//GetProductBrandAsync();
            return Ok(products);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductbyIdAsync(int id)
        {
            var spec = new ProductWithTypeandBrandSpec(id);

            var product = await _Productrepo.GetEntityWithSpec(spec);
            return _mapper.Map<Product, ProductDTO>(product);
            //return new ProductDTO
            //{
            //    Id = product.Id,
            //    Name = product.Name,
            //    Description = product.Description,
            //    PictureUrl = product.PictureUrl,
            //    Price = product.Price,
            //    ProductBrand = product.ProductBrand.Name,
            //    ProductType = product.ProductType.Name

            //};
            
            //return await _Productrepo.GetProductbyIdAsync(id);
            // return await _Productrepo.GetEntityWithSpec(spec);


        }


    }
}
