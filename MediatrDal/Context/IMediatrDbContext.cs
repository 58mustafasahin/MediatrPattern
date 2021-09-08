using MediatrEntity.Entity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MediatrDal.Context
{
    public interface IMediatrDbContext
    {
        DbSet<Category> Categories { get; set; }
        DbSet<Product> Products { get; set; }
        Task<int> SaveChangesAsync();
    }
}
