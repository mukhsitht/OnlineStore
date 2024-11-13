using Data.Catalog;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Data.EntityFramework
{
    public class OnlineStoreDbContext : DbContext
    {
        public OnlineStoreDbContext(DbContextOptions<OnlineStoreDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(b => b.Price).HasPrecision(18, 3);
            modelBuilder.Entity<VWProduct>().Property(b => b.Price).HasPrecision(18, 3);
            modelBuilder.Entity<VWCategory>().HasNoKey().ToView("vwCategories");
            modelBuilder.Entity<VWProduct>().HasNoKey().ToView("vwProducts");

            base.OnModelCreating(modelBuilder);

            // Seeding initial data
            SeedingCategories(modelBuilder);
            SeedingProducts(modelBuilder);
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<VWCategory> VWCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ItemDetail> ItemDetails { get; set; }
        public DbSet<VWProduct> VWProducts { get; set; }
        public async Task<ItemDetail?> GetItemDetails(int id)
        {
            var idParam = new SqlParameter("@ProductId", id);
            var result = await ItemDetails.FromSqlRaw("EXEC GetItemDetails @ProductId", idParam).ToListAsync();
            return result.FirstOrDefault();
        }

        #region Seeding
        private static void SeedingCategories(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Fresh Flowers",
                    CreatedOn = DateTime.Now,
                },
                new Category
                {
                    Id = 2,
                    Name = "Indoor Plants",
                    CreatedOn = DateTime.Now,
                });
        }
        private static void SeedingProducts(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    CategoryId = 1,
                    Name = "Whistler",
                    Description = "10 Stems in one bunch - Closed bloom.",
                    Photo = "whistler.jpg",
                    Price = 10,
                    CreatedOn = DateTime.Now,
                },
                new Product
                {
                    Id = 2,
                    CategoryId = 1,
                    Name = "Nadya",
                    Description = "10 Stems in one bunch - Closed bloom.",
                    Photo = "nadya.jpg",
                    Price = 7,
                    CreatedOn = DateTime.Now,
                });
        }
        #endregion
    }
}
