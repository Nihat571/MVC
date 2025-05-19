using Microsoft.EntityFrameworkCore;
using MVC_New_project.Models;

namespace MVC_New_project.Contexts
{
    public class AppDBContext:DbContext
    {
        private readonly string _connectionStr = @"Server=DESKTOP-N4A540V;Database=GymProgramDB;Trusted_Connection=True;TrustServerCertificate=True;";
        
        public DbSet<GymProgram> GymPrograms { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionStr);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
