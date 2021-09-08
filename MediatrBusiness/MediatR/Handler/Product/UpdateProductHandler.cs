using MediatR;
using MediatrBusiness.Abstract;
using MediatrBusiness.MediatR.Command.Product;
using MediatrEntity.Entity.ReturnMessage;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrBusiness.MediatR.Handler.Product
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, RequestResult>
    {
        private readonly IProductService _productService;

        public UpdateProductHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<RequestResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var list = new List<string>();
            var result = await _productService.UpdateProductAsync(request.UpdateProductDto);
            switch (result)
            {
                case > 0:
                    list.Add("Successful Updating.");
                    return new RequestResult((HttpStatusCode)1000, list, "success");
                case 0:
                    list.Add("Failed Updating.");
                    return new RequestResult((HttpStatusCode)1001, list, "error");
                case -1:
                    list.Add("Product is not found.");
                    return new RequestResult((HttpStatusCode)1001, list, "error");
                default:
                    list.Add("An error occurred during the operation.");
                    return new RequestResult((HttpStatusCode)1001, list, "error");
            }
        }
    }
}
