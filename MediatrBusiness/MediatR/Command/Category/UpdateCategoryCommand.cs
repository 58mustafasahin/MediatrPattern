using MediatR;
using MediatrEntity.Dto.Category;
using MediatrEntity.Entity.ReturnMessage;

namespace MediatrBusiness.MediatR.Command.Category
{
    public record UpdateCategoryCommand : IRequest<RequestResult>
    {
        public UpdateCategoryCommand(UpdateCategoryDto updateCategoryDto)
        {
            UpdateCategoryDto = updateCategoryDto;
        }

        public UpdateCategoryDto UpdateCategoryDto { get; set; }
    }
}
