using Microsoft.EntityFrameworkCore;
using OnlineStoreAPI.Models;

namespace OnlineStoreAPI.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<ProductSeller> ProductSellers { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ProductCategory join table
            modelBuilder.Entity<ProductCategory>()
                .HasKey(pc => new { pc.ProductId, pc.CategoryId });

            modelBuilder.Entity<ProductCategory>()
                .HasOne(p => p.Product)
                .WithMany(pc => pc.ProductCategories)
                .HasForeignKey(p => p.ProductId);

            modelBuilder.Entity<ProductCategory>()
               .HasOne(p => p.Category)
               .WithMany(pc => pc.ProductCategories)
               .HasForeignKey(c => c.CategoryId);

            // ProductSeller join table
            modelBuilder.Entity<ProductSeller>()
                .HasKey(ps => new { ps.ProductId, ps.SellerId });

            modelBuilder.Entity<ProductSeller>()
                .HasOne(p => p.Product)
                .WithMany(ps => ps.ProductSellers)
                .HasForeignKey(p => p.ProductId);

            modelBuilder.Entity<ProductSeller>()
               .HasOne(s => s.Seller)
               .WithMany(ps => ps.ProductSellers)
               .HasForeignKey(s => s.SellerId);
        }
    }
}
