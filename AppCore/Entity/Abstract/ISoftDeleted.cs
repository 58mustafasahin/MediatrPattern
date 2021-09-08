namespace AppCore.Entity.Abstract
{
    public interface ISoftDeleted
    {
        public bool IsDeleted { get; set; }
    }
}
