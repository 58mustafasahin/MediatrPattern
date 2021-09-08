using MediatrBusiness.Abstract;
using MediatrDal.Context;
using MediatrEntity.Dto.Category;
using MediatrEntity.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatrBusiness.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IMediatrDbContext _context;

        public CategoryService(IMediatrDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetCategoryListDto>> GetCategoryListAsync()
        {
            return await _context.Categories
                .Where(p => !p.IsDeleted)
                .Select(p => new GetCategoryListDto
                {
                    Id = p.Id,
                    Name = p.Name
                }).ToListAsync();
        }

        public async Task<GetCategoryDto> GetCategoryByIdAsync(int id)
        {
            var category = await _context.Categories
               .Where(p => !p.IsDeleted && p.Id == id)
               .Select(p =>
                   new GetCategoryDto
                   {
                       Id = p.Id,
                       Name = p.Name
                   }).FirstOrDefaultAsync();
            //If category have, return category. If not, return null.
            return category ?? null;
        }

        public async Task<int> AddCategoryAsync(AddCategoryDto categoryDto)
        {
            var category = new Category
            {
                Name = categoryDto.Name
            };
            await _context.Categories.AddAsync(category);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateCategoryAsync(UpdateCategoryDto categoryDto)
        {
            var currentCategory = await _context.Categories.FindAsync(categoryDto.Id);
            if (currentCategory is { IsDeleted: true }) return -1;
            //If the changes happen, attach changes only different properties.
            _context.Categories.Attach(currentCategory);
            currentCategory.Name = categoryDto.Name;
            currentCategory.MDate = DateTime.Now;
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteCategoryAsync(int id)
        {
            var currentCategory = await _context.Categories.FindAsync(id);
            if (currentCategory is { IsDeleted: true }) return -1;
            //If the changes happen, attach changes only different properties.
            _context.Categories.Attach(currentCategory);
            currentCategory.IsDeleted = true;
            return await _context.SaveChangesAsync();
        }
    }
}
