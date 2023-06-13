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
        bool CreateProduct(List<int> sellerIds, List<int> categoryIds, Product product);
        bool UpdateProduct(List<int> sellerIds, List<int> categoryIds, Product product);
        bool DeleteProduct(Product product);
        bool Save();
    }
}
