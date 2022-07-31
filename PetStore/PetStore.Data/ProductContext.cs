using Microsoft.EntityFrameworkCore;

namespace PetStore.Data
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public string DbPath { get; set; }

        public ProductContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "products.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlite($"Data Source={DbPath}");
    }
}