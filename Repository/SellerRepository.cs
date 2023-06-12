using OnlineStoreAPI.Data;
using OnlineStoreAPI.Interfaces;
using OnlineStoreAPI.Models;

namespace OnlineStoreAPI.Repository
{
    public class SellerRepository : ISellerRepository
    {
        private readonly DataContext _context;

        public SellerRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateSeller(Seller seller)
        {
            _context.Add(seller);
            return Save();
        }

        public ICollection<Product> GetProductBySeller(int sellerId)
        {
            return _context.ProductSellers.Where(p => p.Seller.Id == sellerId).Select(p => p.Product).ToList();
        }

        public Seller GetSeller(int id)
        {
            return _context.Sellers.Where(s => s.Id == id).FirstOrDefault();
        }

        public ICollection<Seller> GetSellerOfAProduct(int productId)
        {
            return _context.ProductSellers.Where(p => p.Product.Id == productId).Select(s => s.Seller).ToList();
        }

        public ICollection<Seller> GetSellers()
        {
            return _context.Sellers.ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool SellerExists(int id)
        {
            return _context.Sellers.Any(s => s.Id == id);
        }

        public bool UpdateSeller(Seller seller)
        {
            _context.Update(seller);
            return Save();
        }
    }
}
