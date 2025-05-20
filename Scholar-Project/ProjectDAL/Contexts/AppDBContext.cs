using Microsoft.EntityFrameworkCore;
using ProjectDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDAL.Contexts
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<CourseCart> carts { get; set; }
    }
}
