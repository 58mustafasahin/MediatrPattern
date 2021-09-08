using AppCore.Entity.Abstract;

namespace MediatrEntity.Dto.Product
{
    public class GetProductDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
