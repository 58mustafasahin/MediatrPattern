using MediatR;
using MediatrEntity.Dto.Product;
using MediatrEntity.Entity.ReturnMessage;

namespace MediatrBusiness.MediatR.Command.Product
{
    public record AddProductCommand : IRequest<RequestResult>
    {
        public AddProductCommand(AddProductDto addProductDto)
        {
            AddProductDto = addProductDto;
        }

        public AddProductDto AddProductDto { get; init; }
    }
}
