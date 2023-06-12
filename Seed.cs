using OnlineStoreAPI.Data;
using OnlineStoreAPI.Models;

namespace OnlineStoreAPI
{
    public class Seed
    {
        private readonly DataContext dataContext;

        public Seed(DataContext context)
        {
            this.dataContext = context;
        }

        public void SeedDataContext()
        {
            if (!dataContext.ProductSellers.Any())
            {
                var productSellers = new List<ProductSeller>()
                {
                    new ProductSeller()
                    {
                        Product = new Product()
                        {
                            Name = "Wireless Bluetooth Headphones",
                            DateListed = new DateTime(2023,6,1),
                            ProductCategories = new List<ProductCategory>()
                            {
                                new ProductCategory { Category = new Category() { Name = "Electronics"} }
                            },
                            Reviews = new List<Review>()
                            {
                                new Review
                                {
                                    Title = "Great sound quality!",
                                    Text = "I'm really impressed with the sound quality of these headphones. Highly recommended.",
                                    Rating = 5,
                                    Reviewer = new Reviewer() { Name = "John Smith" }
                                },
                                new Review
                                {
                                    Title = "Not comfortable",
                                    Text = "The headphones were too tight and uncomfortable to wear for extended periods.",
                                    Rating = 2,
                                    Reviewer = new Reviewer() { Name = "Jane Doe" }
                                },
                            }
                        },
                        Seller = new Seller()
                        {
                            Name = "TechHut",
                            Website = "https://www.techhut.com",
                            Country = new Country() { Name = "United States" }
                        }
                    },
                    new ProductSeller()
                    {
                        Product = new Product()
                        {
                            Name = "Men's Casual T-Shirt",
                            DateListed = new DateTime(2023, 5, 20),
                            ProductCategories = new List<ProductCategory>()
                            {
                                new ProductCategory { Category = new Category() { Name = "Clothing" } }
                            },
                            Reviews = new List<Review>()
                            {
                                new Review
                                {
                                    Title = "Great fit and quality",
                                    Text = "The t-shirt fits perfectly and the fabric feels really nice. Very happy with the purchase.",
                                    Rating = 5,
                                    Reviewer = new Reviewer() { Name = "Amy Johnson" }
                                },
                                new Review
                                {
                                    Title = "Decent shirt",
                                    Text = "The quality of the shirt was decent, but nothing exceptional.",
                                    Rating = 3,
                                    Reviewer = new Reviewer() { Name = "Mark Davis" }
                                },
                            }
                        },
                        Seller = new Seller()
                        {
                            Name = "FashionRise",
                            Website = "https://www.fashionrise.com",
                            Country = new Country() { Name = "Canada" }
                        }
                    },
                    new ProductSeller()
                    {
                        Product = new Product()
                        {
                            Name = "Stainless Steel Kitchen Knife Set",
                            DateListed = new DateTime(2023, 6, 5),
                            ProductCategories = new List<ProductCategory>()
                            {
                                new ProductCategory { Category = new Category() { Name = "Home & Kitchen" } }
                            },
                            Reviews = new List<Review>()
                            {
                                new Review
                                {
                                    Title = "Disappointed with the quality",
                                    Text = "The knives felt cheap and didn't hold their sharpness for long. Not worth the price.",
                                    Rating = 2,
                                    Reviewer = new Reviewer() { Name = "Emily Wilson" }
                                },
                                new Review
                                {
                                    Title = "Great value for the price",
                                    Text = "I'm impressed with the quality of the knives considering the affordable price.",
                                    Rating = 4,
                                    Reviewer = new Reviewer() { Name = "Michael Brown" }
                                },
                            }
                        },
                        Seller = new Seller()
                        {
                            Name = "KitchenPro",
                            Website = "https://www.kitchenpro.com",
                            Country = new Country() { Name = "United Kingdom" }
                        }
                    },
                    new ProductSeller()
                    {
                        Product = new Product()
                        {
                            Name = "Fitness Tracker Watch",
                            DateListed = new DateTime(2023, 5, 15),
                            ProductCategories = new List<ProductCategory>()
                            {
                                new ProductCategory { Category = new Category() { Name = "Sports & Outdoors" } },
                                new ProductCategory { Category = new Category() { Name = "Electronics" } }
                            },
                            Reviews = new List<Review>()
                            {
                                new Review
                                {
                                    Title = "Fantastic features",
                                    Text = "This fitness tracker has all the features I was looking for. It helps me stay motivated and tracks my progress accurately.",
                                    Rating = 5,
                                    Reviewer = new Reviewer() { Name = "Sarah Thompson" }
                                },
                                new Review
                                {
                                    Title = "Poor battery life",
                                    Text = "The battery life is disappointing. It barely lasts a day even with minimal use.",
                                    Rating = 3,
                                    Reviewer = new Reviewer() { Name = "Mark Davis" }
                                },
                            }
                        },
                        Seller = new Seller()
                        {
                            Name = "FitTech",
                            Website = "https://www.fittech.com",
                            Country = new Country() { Name = "United States" }
                        }
                    }
                };
                dataContext.ProductSellers.AddRange(productSellers);
                dataContext.SaveChanges();
            }
        }
    }
}
