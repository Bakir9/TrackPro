using System.Reflection;
using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class StoreContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {

        }
      
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Childs> Childs { get; set; }
        public DbSet<Association> Associations { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<UserActivity> UserActivities { get; set; }
        public DbSet<Income> Incomes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<UserActivity>()
                .HasKey(ua => new { ua.UserId, ua.ActivityId });

            modelBuilder.Entity<User>()
                .HasMany(e => e.Activities)
                .WithMany(e => e.Users)
                .UsingEntity<UserActivity>(
                    a => a.HasOne<Activity>(e => e.Activity).WithMany(e => e.UserActivities).HasForeignKey(e => e.ActivityId),
                    u => u.HasOne<User>(e => e.User).WithMany(e => e.UserActivities).HasForeignKey(e => e.UserId));

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}