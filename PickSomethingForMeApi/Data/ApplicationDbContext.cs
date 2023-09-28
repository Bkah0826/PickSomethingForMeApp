using Microsoft.EntityFrameworkCore;
using PickSomethingForMeApi.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace PickSomethingForMeApi.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Activity> Activities { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Room>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<Activity>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<User>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<Activity>()
            .HasOne(a => a.Room)
            .WithMany(r => r.Activities)
            .HasForeignKey(a => a.RoomId);

        modelBuilder.Entity<Room>()
            .HasMany(r => r.Activities)
            .WithOne(a => a.Room)
            .HasForeignKey(a => a.RoomId);

        modelBuilder.Entity<Room>()
            .HasMany(r => r.Users)
            .WithOne(u => u.Room)
            .HasForeignKey(u => u.RoomId);
    }
}
