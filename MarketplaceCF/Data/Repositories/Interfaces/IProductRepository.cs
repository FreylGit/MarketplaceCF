using MarketplaceCF.Models;

namespace MarketplaceCF.Data.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public IQueryable<Product> Products { get; }
        public Task<bool> CreateProductAsync(Product product);
        public Task<Product?> GetProdutByIdAsync(int id);
        public Task<bool> DeleteProductAsync(int id);
        public Task<bool> UpdateProductAsync(Product product);
        public Task<IEnumerable<Product>?> GetProductsByNameAsync(string name);
    }
}
