using OnlineStoreAPI.Data;
using OnlineStoreAPI.Interfaces;
using OnlineStoreAPI.Models;

namespace OnlineStoreAPI.Repository
{
    public class ProductRepository: IProductRepository
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

        public Product GetProduct(int id)
        {
            return _context.Products.Where(p => p.Id == id).FirstOrDefault();
        }

        public Product GetProduct(string name)
        {
            return _context.Products.Where(p => p.Name == name).FirstOrDefault();
        }

        public decimal GetProductRating(int id)
        {
            var reviews = _context.Reviews.Where(p => p.Product.Id == id);

            if (reviews.Count() <= 0)
            {
                return 0;
            }

            return ((decimal) reviews.Sum(r => r.Rating) / reviews.Count());
        }

        public bool ProductExists(int id)
        {
            return _context.Products.Any(p => p.Id == id);
        }
    }
}
