using AppCore.Entity.Abstract;

namespace MediatrEntity.Dto.Product
{
    public class AddProductDto : IDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
    }
}
