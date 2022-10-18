
using Microsoft.EntityFrameworkCore;

namespace MarketplaceCF.Data
{
    public class ApplicationDbContext: DbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
                
        }
    }
}
