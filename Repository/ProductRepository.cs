using Microsoft.EntityFrameworkCore;
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

        public bool CreateProduct(List<int> sellerIds, List<int> categoryIds, Product product)
        {
            foreach (var sellerId in sellerIds) {
                var seller = _context.Sellers.Where(a => a.Id == sellerId).FirstOrDefault();

                var productSeller = new ProductSeller()
                {
                    Seller = seller,
                    Product = product,
                };

                _context.Add(productSeller);
            }

            foreach (var categoryId in categoryIds)
            {
                var category = _context.Categories.Where(a => a.Id == categoryId).FirstOrDefault();

                var productCategory = new ProductCategory()
                {
                    Category = category,
                    Product = product
                };

                _context.Add(productCategory);
            }

            _context.Add(product);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        // Destroys all ProductSellers rows with the same product and rebuilds them according to param lists.
        // I am aware that this is terrible terrible design, but I don't know how to do it otherwise because
        // I am learning ASP.NET & EF Core for the first time :>
        public bool UpdateProduct(List<int> sellerIds, List<int> categoryIds, Product product)
        {
            _context.RemoveRange(
                _context.ProductSellers.Where(p => p.ProductId == product.Id).ToList());

            _context.RemoveRange(
                _context.ProductCategories.Where(p => p.ProductId == product.Id).ToList());
            
            Save();

            foreach (var sellerId in sellerIds)
            {
                var seller = _context.Sellers.Where(a => a.Id == sellerId).FirstOrDefault();

                var productSeller = new ProductSeller()
                {
                    Seller = seller,
                    Product = product,
                };

                _context.Add(productSeller);
            }

            foreach (var categoryId in categoryIds)
            {
                var category = _context.Categories.Where(a => a.Id == categoryId).FirstOrDefault();

                var productCategory = new ProductCategory()
                {
                    Category = category,
                    Product = product
                };

                _context.Add(productCategory);
            }

            _context.Update(product);
            return Save();
        }

        public bool DeleteProduct(Product product)
        {
            _context.Remove(product);
            return Save();
        }
    }
}
