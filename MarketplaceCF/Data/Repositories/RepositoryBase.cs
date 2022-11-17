using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MarketplaceCF.Data.Repositories
{
    public abstract class RepositoryBase
    {
        public ApplicationDbContext Context { get; set; }
        public RepositoryBase(ApplicationDbContext context)
        {
            Context = context;
        }
        /// <summary>
        /// Проверка на подключение к базе данных
        /// </summary>
        public async Task<bool> CheckConnection()
        {
            try
            {
                await Context.Database.OpenConnectionAsync();
                await Context.Database.CloseConnectionAsync();
            }
            catch (SqlException)
            {
                return false;
            }
            return true;
        }
    }
}
