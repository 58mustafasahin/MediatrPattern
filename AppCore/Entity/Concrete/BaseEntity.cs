using AppCore.Entity.Abstract;

namespace AppCore.Entity.Concrete
{
    public class BaseEntity : Audit, ISoftDeleted
    {
        public BaseEntity()
        {
            IsDeleted = false;
        }

        public bool IsDeleted { get; set; }
    }
}
