using OnlineStoreAPI.Models;

namespace OnlineStoreAPI.Interfaces
{
    public interface IProductRepository
    {
        ICollection<Product> GetProducts();
    }
}
