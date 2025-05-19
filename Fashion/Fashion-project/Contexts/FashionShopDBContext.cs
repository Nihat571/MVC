using Fashion_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Fashion_Project.Contexts
{
    public class FashionShopDBContext:DbContext
    {
        private readonly string _connectionString = @"Server=DESKTOP-N4A540V;Database=FashionShopDB;Trusted_Connection=True;TrustServerCertificate=True;";
        
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
