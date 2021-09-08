using MediatrEntity.Dto.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediatrBusiness.Abstract
{
    public interface IProductService
    {
        Task<GetProductDto> GetProductByIdAsync(int id);
        Task<IEnumerable<GetProductListDto>> GetProductListAsync();
        Task<int> AddProductAsync(AddProductDto productDto);
        Task<int> UpdateProductAsync(UpdateProductDto productDto);
        Task<int> DeleteProductAsync(int id);
    }
}
