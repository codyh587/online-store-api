using OnlineStoreAPI.Data;
using OnlineStoreAPI.Models;

namespace OnlineStoreAPI.Repository
{
    public class ProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Product> GetProducts()
        {
            return _context.Products.OrderBy(p => p.Id).ToList();
        }
    }
}
