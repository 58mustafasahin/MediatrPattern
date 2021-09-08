using MediatR;
using MediatrBusiness.Abstract;
using MediatrBusiness.MediatR.Query.Category;
using MediatrEntity.Dto.Category;
using MediatrEntity.Entity.ReturnMessage;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrBusiness.MediatR.Handler.Category
{
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, GetReturnMessageResult<GetCategoryDto>>
    {
        private readonly ICategoryService _categoryService;

        public GetCategoryByIdHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<GetReturnMessageResult<GetCategoryDto>> Handle(GetCategoryByIdQuery request,
            CancellationToken cancellationToken)
        {
            var result = await _categoryService.GetCategoryByIdAsync(request.CategoryId);

            if (result == null)
            {
                var list = new List<string> { "Category is not found." };
                return new GetReturnMessageResult<GetCategoryDto>((HttpStatusCode)1001, list, "error");
            }
            return new GetReturnMessageResult<GetCategoryDto>((HttpStatusCode)1000, result, "success");
        }
    }
}
