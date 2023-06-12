using OnlineStoreAPI.Models;

namespace OnlineStoreAPI.Interfaces
{
    public interface IProductRepository
    {
        ICollection<Product> GetProducts();
        Product GetProduct(int id);
        Product GetProduct(string name);
        decimal GetProductRating(int id);
        bool productExists(int id);
    }
}
