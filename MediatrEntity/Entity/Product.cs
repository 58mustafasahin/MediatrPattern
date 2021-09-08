using AppCore.Entity.Concrete;

namespace MediatrEntity.Entity
{
    public class Product : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public Category CategoryFK { get; set; }
    }
}
