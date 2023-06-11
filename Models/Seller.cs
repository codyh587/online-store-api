namespace OnlineStoreAPI.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public Country Country { get; set; }
        public ICollection<ProductSeller> ProductSellers { get; set; }
    }
}
