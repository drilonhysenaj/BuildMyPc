using BuildMyPcApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BuildMyPcApi.Database;

public class BuildMyPcDbContext : DbContext
{
    public BuildMyPcDbContext(DbContextOptions<BuildMyPcDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .HasPrecision(18, 2);
    }
}