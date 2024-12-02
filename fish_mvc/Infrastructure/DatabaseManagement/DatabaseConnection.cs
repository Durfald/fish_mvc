using fish_mvc.Models;
using Microsoft.EntityFrameworkCore;

// ReSharper disable PropertyCanBeMadeInitOnly.Global
namespace fish_mvc.Infrastructure.DatabaseManagement;
public class DatabaseConnection : DbContext
{
    public DbSet<Marker> Markers { get; set; } = null!;
    public DbSet<ARENDATOR> Arendators { get; set; } = null!;
    public DbSet<Reservation> Reservations { get; set; } = null!;
    public DbSet<User> Users { get; set; } = default!;


    public DatabaseConnection (DbContextOptions<DatabaseConnection> options)
        : base(options)
    {
        EnsureCreated(this);

    }

    protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
    { base.OnConfiguring(optionsBuilder); }

    protected override void OnModelCreating (ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("utf8_general_ci");
        base.OnModelCreating(modelBuilder);
    }

    private static void EnsureCreated (DatabaseConnection dbContext)
    {
        //dbContext.Database.EnsureDeleted();
        dbContext.Database.EnsureCreated();
        dbContext.SaveChanges();

        if ( dbContext.Users.FirstOrDefault(x => x.Username == "admin") == null )
        {
            dbContext.Users.Add(new User()
            {
                Username = "admin",
                Password = "admin",
                Role = "admin"
            });
        }

        dbContext.SaveChanges();
    }
}