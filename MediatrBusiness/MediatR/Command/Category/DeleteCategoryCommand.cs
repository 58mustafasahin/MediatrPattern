using MediatR;
using MediatrEntity.Entity.ReturnMessage;

namespace MediatrBusiness.MediatR.Command.Category
{
    public record DeleteCategoryCommand : IRequest<RequestResult>
    {
        public DeleteCategoryCommand(int categoryId)
        {
            CategoryId = categoryId;
        }

        public int CategoryId { get; set; }
    }
}
