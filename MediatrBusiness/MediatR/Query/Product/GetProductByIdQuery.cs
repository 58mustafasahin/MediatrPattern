using MediatR;
using MediatrEntity.Dto.Product;
using MediatrEntity.Entity.ReturnMessage;

namespace MediatrBusiness.MediatR.Query.Product
{
    public record GetProductByIdQuery : IRequest<GetReturnMessageResult<GetProductDto>>
    {
        public GetProductByIdQuery(int productId)
        {
            ProductId = productId;
        }

        public int ProductId { get; init; }
    }
}
