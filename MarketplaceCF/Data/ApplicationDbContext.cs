
using MarketplaceCF.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketplaceCF.Data
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Product> Products { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
                
        }
    }
}
