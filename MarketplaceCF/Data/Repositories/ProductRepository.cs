using MarketplaceCF.Data.Repositories.Interfaces;
using MarketplaceCF.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketplaceCF.Data.Repositories
{
    public class ProductRepository :RepositoryBase, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context):base(context)
        {   
        }

        public IQueryable<Product> Products => Context.Products;

        public async Task<bool> CreateProductAsync(Product product)
        {
            if(await CheckConnection())
            {
               await Context.Products.AddAsync(product);
               await Context.SaveChangesAsync();
               return true;
            }
            return false;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            if (await CheckConnection()) 
            {
                var product = await Context.Products.FindAsync(id);
                if (product != null)
                {
                    Context.Products.Remove(product);
                    await Context.SaveChangesAsync();
                    return true;
                }
            }
            return false;
        }

        public async Task<IEnumerable<Product>?> GetProductsByNameAsync(string name)
        {
            if(await CheckConnection())
            {
                var products = Context.Products.Where(p=>p.Title.ToLower().Contains(name));
                return products;
            }
            return null;
        }

        public async Task<Product?> GetProdutByIdAsync(int id)
        {
            if (await CheckConnection())
            {
                var product = await Context.Products.Where(p=>p.Id == id).FirstOrDefaultAsync();
                if (product != null)
                {
                    return product;
                }
            }
            return null;
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            if (await CheckConnection())
            {
                try
                {
                    Context.Products.Update(product);
                    await Context.SaveChangesAsync();
                }catch(NotSupportedException)
                {
                    return false;
                }
                return true;
               
            }
            return false;
        }
    }
}
