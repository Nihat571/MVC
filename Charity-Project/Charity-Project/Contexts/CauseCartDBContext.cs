using Charity_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Charity_Project.Contexts
{
    public class CauseCartDBContext:DbContext
    {
        private readonly string _connectionString = @"Server=DESKTOP-GTVND9D\SQLEXPRESS;Database=CharityPrDB;Trusted_Connection=True;TrustServerCertificate=True;";
        
        public DbSet<CauseCart> CauseCart { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
