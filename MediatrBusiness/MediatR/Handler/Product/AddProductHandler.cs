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
    public class AddProductHandler : IRequestHandler<AddProductCommand, RequestResult>
    {
        private readonly IProductService _productService;

        public AddProductHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<RequestResult> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var list = new List<string>();
            var result = await _productService.AddProductAsync(request.AddProductDto);
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
