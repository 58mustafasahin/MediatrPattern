using MediatR;
using MediatrEntity.Dto.Product;
using System.Collections.Generic;

namespace MediatrBusiness.MediatR.Query.Product
{
    public record GetProductListQuery : IRequest<IEnumerable<GetProductListDto>>
    {
    }
}
