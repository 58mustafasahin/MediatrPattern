using MediatR;
using MediatrBusiness.Abstract;
using MediatrBusiness.MediatR.Query.Category;
using MediatrEntity.Dto.Category;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrBusiness.MediatR.Handler.Category
{
    public class GetCategoryListHandler : IRequestHandler<GetCategoryListQuery, IEnumerable<GetCategoryListDto>>
    {
        private readonly ICategoryService _categoryService;

        public GetCategoryListHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IEnumerable<GetCategoryListDto>> Handle(GetCategoryListQuery request,
            CancellationToken cancellationToken)
        {
            return await _categoryService.GetCategoryListAsync();
        }
    }
}
