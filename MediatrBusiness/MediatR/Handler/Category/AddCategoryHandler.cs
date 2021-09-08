using MediatR;
using MediatrBusiness.Abstract;
using MediatrBusiness.MediatR.Command.Category;
using MediatrEntity.Entity.ReturnMessage;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrBusiness.MediatR.Handler.Category
{
    public class AddCategoryHandler : IRequestHandler<AddCategoryCommand, RequestResult>
    {
        private readonly ICategoryService _categoryService;

        public AddCategoryHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<RequestResult> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var list = new List<string>();
            var result = await _categoryService.AddCategoryAsync(request.AddCategoryDto);
            switch (result)
            {
                case > 0:
                    list.Add("Successful Adding.");
                    return new RequestResult((HttpStatusCode)1000, list, "success");
                case 0:
                    list.Add("Failed Adding.");
                    return new RequestResult((HttpStatusCode)1001, list, "error");
                default:
                    list.Add("An error occurred during the operation.");
                    return new RequestResult((HttpStatusCode)1001, list, "error");
            }
        }
    }
}
