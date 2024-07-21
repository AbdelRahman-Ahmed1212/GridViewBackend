using Microsoft.EntityFrameworkCore;
using Task2.Models;

namespace Task2.DBContext
{
    public class Context : DbContext
    {
        public DbSet<DaUser> DaUsers { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=10.0.0.18;Database=QDesk_training;User Id=alqemam_msql;Password=123456789;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DaUser>().HasKey(a => a.id);
            base.OnModelCreating(modelBuilder);
        }
    }
}
