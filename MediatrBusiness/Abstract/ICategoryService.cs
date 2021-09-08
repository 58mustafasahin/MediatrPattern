using MediatrEntity.Dto.Category;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediatrBusiness.Abstract
{
    public interface ICategoryService
    {
        Task<GetCategoryDto> GetCategoryByIdAsync(int id);
        Task<IEnumerable<GetCategoryListDto>> GetCategoryListAsync();
        Task<int> AddCategoryAsync(AddCategoryDto categoryDto);
        Task<int> UpdateCategoryAsync(UpdateCategoryDto categoryDto);
        Task<int> DeleteCategoryAsync(int id);
    }
}
