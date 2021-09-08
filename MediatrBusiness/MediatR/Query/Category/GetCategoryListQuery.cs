using MediatR;
using MediatrEntity.Dto.Category;
using System.Collections.Generic;

namespace MediatrBusiness.MediatR.Query.Category
{
    public record GetCategoryListQuery : IRequest<IEnumerable<GetCategoryListDto>>
    {
    }
}
