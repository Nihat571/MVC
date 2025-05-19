using Forella.Models;
using Microsoft.EntityFrameworkCore;

namespace Forella.Contexts
{
    public class FlowersDBContext:DbContext
    {
        private readonly string _connectionString = @"Server=DESKTOP-N4A540V;Database=FlowersDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public DbSet<Flower> Flowers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
