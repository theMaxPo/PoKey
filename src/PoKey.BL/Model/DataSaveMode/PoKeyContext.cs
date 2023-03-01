using Microsoft.EntityFrameworkCore;

namespace PoKey.BL.Model;

public class PoKeyContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;

    public PoKeyContext()
    {
        // Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=db;Port=5432;Database=dbPoKey;Username=postgres;Password=postgres");
    }
}