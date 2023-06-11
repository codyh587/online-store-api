namespace OnlineStoreAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime DateListed { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<ProductSeller> ProductSellers { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
