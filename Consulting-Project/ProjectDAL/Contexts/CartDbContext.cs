using Microsoft.EntityFrameworkCore;
using ProjectDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDAL.Contexts
{
    public class CartDbContext:DbContext
    {
        public CartDbContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<TeamCart> carts { get; set; }
    }
}
