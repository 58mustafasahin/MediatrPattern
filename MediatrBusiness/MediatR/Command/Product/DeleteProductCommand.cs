using MediatR;
using MediatrEntity.Entity.ReturnMessage;

namespace MediatrBusiness.MediatR.Command.Product
{
    public record DeleteProductCommand : IRequest<RequestResult>
    {
        public DeleteProductCommand(int productId)
        {
            ProductId = productId;
        }

        public int ProductId { get; set; }
    }
}
