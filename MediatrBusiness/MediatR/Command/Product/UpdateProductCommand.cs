using MediatR;
using MediatrEntity.Dto.Product;
using MediatrEntity.Entity.ReturnMessage;

namespace MediatrBusiness.MediatR.Command.Product
{
    public record UpdateProductCommand : IRequest<RequestResult>
    {
        public UpdateProductCommand(UpdateProductDto updateProductDto)
        {
            UpdateProductDto = updateProductDto;
        }

        public UpdateProductDto UpdateProductDto { get; set; }
    }
}
