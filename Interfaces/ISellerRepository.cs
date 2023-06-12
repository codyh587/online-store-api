using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStoreAPI.Models;

namespace OnlineStoreAPI.Interfaces
{
    public interface ISellerRepository
    {
        ICollection<Seller> GetSellers();
        Seller GetSeller(int id);
        ICollection<Seller> GetSellerOfAProduct(int productId);
        ICollection<Product> GetProductBySeller(int sellerId);
        bool SellerExists(int id);
        bool CreateSeller(Seller seller);
        bool UpdateSeller(Seller seller);
        bool DeleteSeller(Seller seller);
        bool Save();
    }
}
