using OnlineStoreAPI.Models;

namespace OnlineStoreAPI.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int id);
        ICollection<Product> GetProductByCategory(int categoryId);
        bool CategoryExists(int id);
    }
}
