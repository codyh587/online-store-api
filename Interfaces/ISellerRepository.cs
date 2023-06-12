﻿using OnlineStoreAPI.Models;

namespace OnlineStoreAPI.Interfaces
{
    public interface ISellerRepository
    {
        ICollection<Seller> GetSellers();
        Seller GetSeller(int id);
        ICollection<Seller> GetSellerOfAProduct(int productId);
        ICollection<Product> GetProductBySeller(int sellerId);
        bool SellerExists(int id);
    }
}