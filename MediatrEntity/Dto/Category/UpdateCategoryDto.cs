using AppCore.Entity.Abstract;

namespace MediatrEntity.Dto.Category
{
    public class UpdateCategoryDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
