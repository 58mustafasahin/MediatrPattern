using MediatR;
using MediatrBusiness.Abstract;
using MediatrBusiness.MediatR.Query.Product;
using MediatrEntity.Dto.Product;
using MediatrEntity.Entity.ReturnMessage;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrBusiness.MediatR.Handler.Product
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, GetReturnMessageResult<GetProductDto>>
    {
        private readonly IProductService _productService;

        public GetProductByIdHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<GetReturnMessageResult<GetProductDto>> Handle(GetProductByIdQuery request,
            CancellationToken cancellationToken)
        {
            var result = await _productService.GetProductByIdAsync(request.ProductId);

            if (result == null)
            {
                var list = new List<string> { "Product is not found." };
                return new GetReturnMessageResult<GetProductDto>((HttpStatusCode)1001, list, "error");
            }
            return new GetReturnMessageResult<GetProductDto>((HttpStatusCode)1000, result, "success");
        }
    }
}
