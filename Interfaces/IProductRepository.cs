using OnlineStoreAPI.Models;

namespace OnlineStoreAPI.Interfaces
{
    public interface IProductRepository
    {
        ICollection<Product> GetProducts();
        Product GetProduct(int id);
        Product GetProduct(string name);
        decimal GetProductRating(int id);
        bool ProductExists(int id);
        bool CreateProduct(int sellerId, int categoryId, Product product);
        bool Save();
    }
}
