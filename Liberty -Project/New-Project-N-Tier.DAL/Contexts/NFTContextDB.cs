using Microsoft.EntityFrameworkCore;
using New_Project_N_Tier.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_Project_N_Tier.DAL.Contexts
{
    public class NFTContextDB:DbContext
    {
        private readonly string _connectionString = @"Server=DESKTOP-GTVND9D\SQLEXPRESS;Database=NFTDB;Trusted_Connection=True;TrustServerCertificate=True;";
        
        public DbSet<NTFCart> NFTCart { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
