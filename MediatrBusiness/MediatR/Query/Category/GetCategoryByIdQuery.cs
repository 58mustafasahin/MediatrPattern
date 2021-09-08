using MediatR;
using MediatrEntity.Dto.Category;
using MediatrEntity.Entity.ReturnMessage;

namespace MediatrBusiness.MediatR.Query.Category
{
    public record GetCategoryByIdQuery : IRequest<GetReturnMessageResult<GetCategoryDto>>
    {
        public GetCategoryByIdQuery(int categoryId)
        {
            CategoryId = categoryId;
        }

        public int CategoryId { get; init; }
    }
}
