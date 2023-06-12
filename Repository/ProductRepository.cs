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

        public bool CreateProduct(int sellerId, int categoryId, Product product)
        {
            var productSellerEntity = _context.Sellers.Where(a => a.Id == sellerId).FirstOrDefault();
            var category = _context.Categories.Where(a => a.Id == categoryId).FirstOrDefault();

            var productSeller = new ProductSeller()
            {
                Seller = productSellerEntity,
                Product = product,
            };

            _context.Add(productSeller);

            var productCategory = new ProductCategory()
            {
                Category = category,
                Product = product
            };

            _context.Add(productCategory);

            _context.Add(product);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateProduct(int sellerId, int categoryId, Product product)
        {
            _context.Update(product);
            return Save();
        }
    }
}
