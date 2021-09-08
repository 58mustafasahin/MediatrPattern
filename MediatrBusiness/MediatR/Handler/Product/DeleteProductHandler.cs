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
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, RequestResult>
    {
        private readonly IProductService _productService;

        public DeleteProductHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<RequestResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var list = new List<string>();
            var result = await _productService.DeleteProductAsync(request.ProductId);
            switch (result)
            {
                case > 0:
                    list.Add("Successful Deleting.");
                    return new RequestResult((HttpStatusCode)1000, list, "success");
                case 0:
                    list.Add("Failed Deleting.");
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
