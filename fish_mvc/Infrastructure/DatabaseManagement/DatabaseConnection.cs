using fish_mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace fish_mvc.Infrastructure.DatabaseManagement
{
    public class DatabaseConnection : DbContext
    {
        public DbSet<Marker> Markers { get; set; } = null!;
        public DbSet<ARENDATOR> Arendators { get; set; } = null!;
        public DbSet<Reservation> Reservations { get; set; } = null!;

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
        public DatabaseConnection()
        {
            Database.EnsureCreated();
        }
        public DatabaseConnection(DbContextOptions<DatabaseConnection> options)
               : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
