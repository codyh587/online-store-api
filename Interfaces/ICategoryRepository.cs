using OnlineStoreAPI.Models;

namespace OnlineStoreAPI.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int id);
        ICollection<Product> GetProductByCategory(int categoryId);
        ICollection<Category> GetCategoryOfAProduct(int productId);
        bool CategoryExists(int id);
        bool CreateCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(Category category);
        bool Save();
    }
}
