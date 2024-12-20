using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var superAdminRoleId = "5c26f2c8-63a8-424e-a94e-d2c9d3e64465";
            var adminRoleId = "8fbb54de-b083-43e4-8f80-eeb368dfaaf1";
            var userRoleId = "b0106cc1-7d4b-412b-997a-6a138ccac43b";

            // Seed Roles (User, Admin, Super Admin)
            var roles = new List<IdentityRole>
                {
                    new IdentityRole()
                    {
                        Name = "SuperAdmin",
                        NormalizedName = "SuperAdmin",
                        Id = superAdminRoleId,
                        ConcurrencyStamp = superAdminRoleId
                    },
                    new IdentityRole()
                    {
                        Name = "Admin",
                        NormalizedName = "Admin",
                        Id = adminRoleId,
                        ConcurrencyStamp = adminRoleId
                    },
                    new IdentityRole()
                    {
                        Name = "User",
                        NormalizedName = "User",
                        Id = userRoleId,
                        ConcurrencyStamp = userRoleId
                    }
                };
            builder.Entity<IdentityRole>().HasData(roles);

            // Seed Super Admin User
            var superAdminId = "f663ed14-3d8e-40b5-adc0-46e71725edd0";
            var superAdminUser = new IdentityUser()
            {
                Id = superAdminId,
                UserName = "superadmin@bloggie.com",
                Email = "superadmin@bloggie.com"
            };
            superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>()
                .HashPassword(superAdminUser, "superadmin123");

            builder.Entity<IdentityUser>().HasData(superAdminUser);

            // Add All Roles To Super Admin User
            var superAdminRoles = new List<IdentityUserRole<string>>()
            {
                new IdentityUserRole<string>
                {
                    RoleId = superAdminRoleId,
                    UserId = superAdminId
                },

                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = superAdminId
                },

                new IdentityUserRole<string>
                {
                    RoleId = userRoleId,
                    UserId = superAdminId
                }
            };

            builder.Entity<IdentityUserRole<string>>().HasData(superAdminRoles);
            
        }
    }
}
