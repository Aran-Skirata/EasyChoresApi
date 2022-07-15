using EasyChoresApi.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EasyChoresApi.Data;

public class DataContext : IdentityDbContext<User,Role, int, IdentityUserClaim<int>,
UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Event> Events { get; set; }
    public DbSet<Reminder> Reminders { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<User>().HasMany(u => u.UserRoles)
            .WithOne(u => u.User)
            .HasForeignKey(ur => ur.UserId)
            .IsRequired();

        builder.Entity<Role>().HasMany(r => r.UserRoles)
            .WithOne(r => r.Role)
            .HasForeignKey(ur => ur.RoleId)
            .IsRequired();


        builder.Entity<User>().HasMany(u => u.UserEvents)
            .WithOne(u => u.User)
            .HasForeignKey(u => u.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Event>().HasMany(u => u.UserEvents)
            .WithOne(u => u.Event)
            .HasForeignKey(u => u.EventId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.Entity<User>().HasMany(u => u.UserReminders)
            .WithOne(u => u.User)
            .HasForeignKey(u => u.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Reminder>().HasMany(u => u.UserReminders)
            .WithOne(u => u.Reminder)
            .HasForeignKey(u => u.ReminderId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<User>().HasMany(u => u.OwnedEvents)
            .WithOne(e => e.Owner)
            .HasForeignKey(e => e.OwnerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<User>().HasMany(u => u.OwnedReminders)
            .WithOne(r => r.Owner)
            .HasForeignKey(r => r.OwnerId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}