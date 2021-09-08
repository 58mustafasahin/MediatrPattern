using AppCore.Entity.Abstract;

namespace MediatrEntity.Dto.Category
{
    public class GetCategoryDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
