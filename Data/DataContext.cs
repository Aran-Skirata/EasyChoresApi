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

    public DbSet<CalendarEvent> CalendarEvents { get; set; }
    public DbSet<CalendarReminder> CalendarReminders { get; set; }
 

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

        builder.Entity<User>().HasMany(u => u.OwnedCalendarEvents)
            .WithOne(e => e.Owner)
            .HasForeignKey(e => e.OwnerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<User>().HasMany(u => u.OwnedCalendarReminders)
            .WithOne(r => r.Owner)
            .HasForeignKey(r => r.OwnerId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}