using MediatR;
using MediatrEntity.Dto.Category;
using MediatrEntity.Entity.ReturnMessage;

namespace MediatrBusiness.MediatR.Command.Category
{
    public record AddCategoryCommand : IRequest<RequestResult>
    {
        public AddCategoryCommand(AddCategoryDto addCategoryDto)
        {
            AddCategoryDto = addCategoryDto;
        }

        public AddCategoryDto AddCategoryDto { get; set; }
    }
}
