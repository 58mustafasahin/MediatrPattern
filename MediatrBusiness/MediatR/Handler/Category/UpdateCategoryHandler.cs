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
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, RequestResult>
    {
        private readonly ICategoryService _categoryService;

        public UpdateCategoryHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<RequestResult> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var list = new List<string>();
            var result = await _categoryService.UpdateCategoryAsync(request.UpdateCategoryDto);
            switch (result)
            {
                case > 0:
                    list.Add("Successful Updating.");
                    return new RequestResult((HttpStatusCode)1000, list, "success");
                case 0:
                    list.Add("Failed Updating.");
                    return new RequestResult((HttpStatusCode)1001, list, "error");
                case -1:
                    list.Add("Category is not found.");
                    return new RequestResult((HttpStatusCode)1001, list, "error");
                default:
                    list.Add("An error occurred during the operation.");
                    return new RequestResult((HttpStatusCode)1001, list, "error");
            }
        }
    }
}
