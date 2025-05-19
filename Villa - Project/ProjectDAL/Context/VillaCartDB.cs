using Microsoft.EntityFrameworkCore;
using ProjectDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDAL.Context
{
    public class VillaCartDB:DbContext
    {

        private readonly string _connectionString = @"Server=DESKTOP-GTVND9D\SQLEXPRESS;Database=VillaDB;Trusted_Connection=True;TrustServerCertificate=True;";
        public DbSet<VillaCart> villaCarts { get; set; } 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
           
            base.OnConfiguring(optionsBuilder);
        }
    }
}
