using AngEcommerceApi.Data;
using AngEcommerceApi.Inteface;
using AngEcommerceApi.Model;
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
        private readonly IProductRepository _repo;
        public ProductController(IProductRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]

        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _repo.GetProductAsync();
            return Ok(products);
        }

        [HttpGet("Types")]
        public async Task<ActionResult<List<ProductType>>> GetProductTypes()
        {
            var products = await _repo.GetProductTypeAsync();
            return Ok(products);
        }

        [HttpGet("Brands")]
        public async Task<ActionResult<List<Product>>> GetProductBrands()
        {
            var products = await _repo.GetProductBrandAsync();
            return Ok(products);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductbyIdAsync(int id)
        {
            return await _repo.GetProductbyIdAsync(id);
        }


    }
}
