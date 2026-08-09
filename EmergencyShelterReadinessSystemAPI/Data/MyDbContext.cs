using EmergencyShelterReadinessSystemAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace EmergencyShelterReadinessSystemAPI.Data;

public class MyDbContext:DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options): base(options) 
    { 
    }
    public DbSet<Area> Areas { get; set; }
    public DbSet<Shelter> Shelters { get; set; }
    public DbSet<Inspection> Inspections { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Area>()
            .HasMany(s => s.Shelters)
            .WithOne(s => s.Area)
            .HasForeignKey(s => s.AreaId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Shelter>()
            .HasMany(i => i.Inspections)
            .WithOne(i => i.Shelter)
            .HasForeignKey(i => i.ShelterId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
