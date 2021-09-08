using MediatrBusiness.Abstract;
using MediatrDal.Context;
using MediatrEntity.Dto.Product;
using MediatrEntity.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatrBusiness.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IMediatrDbContext _context;

        public ProductService(IMediatrDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetProductListDto>> GetProductListAsync()
        {
            return await _context.Products
                .Include(p => p.CategoryFK)
                .Where(p => !p.IsDeleted)
                .Select(p => new GetProductListDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    CategoryId = p.CategoryId,
                    CategoryName = p.CategoryFK.Name
                }).AsNoTracking().ToListAsync();
        }

        public async Task<GetProductDto> GetProductByIdAsync(int id)
        {
            var product = await _context.Products
               .Include(p => p.CategoryFK)
               .Where(p => !p.IsDeleted && p.Id == id)
               .Select(p => new GetProductDto
               {
                   Id = p.Id,
                   Name = p.Name,
                   Price = p.Price,
                   CategoryId = p.CategoryId,
                   CategoryName = p.CategoryFK.Name
               }).AsNoTracking().FirstOrDefaultAsync();
            //If product have, return product. If not, return null.
            return product ?? null;
        }

        public async Task<int> AddProductAsync(AddProductDto productDto)
        {
            var newProduct = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                CategoryId = productDto.CategoryId
            };
            await _context.Products.AddAsync(newProduct);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateProductAsync(UpdateProductDto productDto)
        {
            var currentProduct = await _context.Products.FindAsync(productDto.Id);
            if (currentProduct is { IsDeleted: true }) return -1;
            //If the changes happen, attach changes only different properties.
            _context.Products.Attach(currentProduct);
            currentProduct.Name = productDto.Name;
            currentProduct.Price = productDto.Price;
            currentProduct.CategoryId = productDto.CategoryId;
            currentProduct.MDate = DateTime.Now;

            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteProductAsync(int id)
        {
            var currentProduct = await _context.Products.FindAsync(id);
            if (currentProduct is { IsDeleted: true }) return -1;
            //If the changes happen, attach changes only different properties.
            _context.Products.Attach(currentProduct);
            currentProduct.IsDeleted = true;
            return await _context.SaveChangesAsync();
        }
    }
}
