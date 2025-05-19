using Carvilla.Models;
using Microsoft.EntityFrameworkCore;

namespace Carvilla.Contexts
{
    public class CarsDB:DbContext
    {
        private readonly string _connectionString = @"Server=DESKTOP-GTVND9D\SQLEXPRESS;Database=CarDB;Trusted_Connection=True;TrustServerCertificate=True;";
        
        public DbSet<Car> cars { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
