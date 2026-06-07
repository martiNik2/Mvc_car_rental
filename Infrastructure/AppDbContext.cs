using Microsoft.EntityFrameworkCore;
using Core;
namespace Infrastructure;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options){}
    public DbSet<User> Users{get;set;}
    public DbSet<Vehicle> Vehicles{get;set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>()
        .HasIndex(u=>u.UserName).
        IsUnique();
    }
}
