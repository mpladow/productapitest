using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Interfaces;
using ProductApi.Models;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        // GET api/product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> Get()
        {
            var products = await _productRepository.GetProducts();


            // dummy data
            var prod1 = new ProductDto()
            {
                Id = 1,
                Name = "prod 1",
                Description = "Description1",
                Price = 3.69
            };
            var xx = new List<ProductDto>();
            xx.Add(prod1);
            return Ok(xx);
        }

        // GET api/product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> Get(int id)
        {
            var product = await _productRepository.GetProductById(id);

            return Ok(product);
        }

        // POST api/product/add
        [HttpPost]
        public async Task<ActionResult<ProductDto>> Add(ProductDto product)
        {
            var result = await _productRepository.AddProduct(product);
            return Ok(result);
        }
        // POST api/product/edit
        public async Task<ActionResult<ProductDto>> Edit(ProductDto product)
        {
            var result = await _productRepository.EditProduct(product);
            return Ok(result);
        }

        // DELETE api/product/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _productRepository.DeleteProductById(id);

        }
    }
}
