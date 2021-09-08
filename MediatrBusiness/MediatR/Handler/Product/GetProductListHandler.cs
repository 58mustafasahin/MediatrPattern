using MediatR;
using MediatrBusiness.Abstract;
using MediatrBusiness.MediatR.Query.Product;
using MediatrEntity.Dto.Product;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrBusiness.MediatR.Handler.Product
{
    public class GetProductListHandler : IRequestHandler<GetProductListQuery, IEnumerable<GetProductListDto>>
    {
        private readonly IProductService _productService;

        public GetProductListHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IEnumerable<GetProductListDto>> Handle(GetProductListQuery request,
            CancellationToken cancellationToken)
        {
            return await _productService.GetProductListAsync();
        }
    }
}
