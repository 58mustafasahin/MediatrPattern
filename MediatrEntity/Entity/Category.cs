using AppCore.Entity.Concrete;
using System.Collections.Generic;

namespace MediatrEntity.Entity
{
    public class Category : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}