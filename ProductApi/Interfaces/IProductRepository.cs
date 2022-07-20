using ProductApi.Contexts;
using ProductApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Interfaces
{
    public interface IProductRepository
    {
        Task<ProductDto> AddProduct(ProductDto product);
        Task<bool> EditProduct(ProductDto product);
        Task<IEnumerable<ProductDto>> GetProducts();
        Task<ProductDto> GetProductById(int id);
        bool DeleteProductById(int id);
    }
}
