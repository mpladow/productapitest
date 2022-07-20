using Microsoft.EntityFrameworkCore;
using ProductApi.Contexts;
using ProductApi.Interfaces;
using ProductApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly _TestContext _context;
        public ProductRepository(_TestContext context)
        {
            _context = context;
        }

        public async Task<ProductDto> AddProduct(ProductDto product)
        {
            var entity = new Product();

            // ideally use AutoMap
            entity.Id = product.Id;
            entity.Name = product.Name;
            entity.Description = product.Description;
            entity.Price = product.Price;

            _context.Add(entity);
            _context.SaveChangesAsync();

            product.Id = entity.Id;

            return product;
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            return await _context.Products.Where(p => p.DeletedAt != null).Select(s => new ProductDto {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                Price = s.Price
            }).ToListAsync();
        }

        public async Task<ProductDto> GetProductById(int id)
        {
            var entity = await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
            var product = new ProductDto()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Price = entity.Price
            };
            return product;
        }

        public async Task<bool> EditProduct(ProductDto product)
        {
            var entity = _context.Products.FirstOrDefault(p => p.Id == product.Id);
            // ideally use AutoMap
            entity.Id = product.Id;
            entity.Name = product.Name;
            entity.Description = product.Description;
            entity.Price = product.Price;

            _context.Update(entity);
            _context.SaveChanges();
            return _context.Entry(entity).State == EntityState.Modified;
        }

        public bool DeleteProductById(int id)
        {
            var entityToDelete = _context.Products.FirstOrDefault(x => x.Id == id);
            _context.Products.Remove(entityToDelete);
            _context.SaveChanges();
            return _context.Entry(entityToDelete).State == EntityState.Deleted;
        }

    }
}
