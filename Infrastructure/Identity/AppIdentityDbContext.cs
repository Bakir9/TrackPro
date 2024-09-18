using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Identity
{
    // public class AppIdentityDbContext : IdentityDbContext<User>
    // {
    //     public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
    //     {
    //     }

    //     protected override void OnModelCreating(ModelBuilder builder)
    //     {
    //         base.OnModelCreating(builder);
    //         builder.Entity<IdentityRole>(e => e.ToTable("Roles"));
    //         builder.Entity<IdentityUserRole<string>>(entity => entity.ToTable("UserRoles"));
    //         builder.Entity<IdentityUserClaim<string>>(entity => entity.ToTable("UserClaims"));
    //         builder.Entity<IdentityUserLogin<string>>(entity => entity.ToTable("UserLogins"));
    //         builder.Entity<IdentityRoleClaim<string>>(entity => entity.ToTable("RoleClaims"));
    //     }
    // }
}