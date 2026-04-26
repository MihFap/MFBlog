using MFBlog.Core.Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace MFBlog.Data
{
    public class DataSeeder
    {
        public async Task SeedAsync(MFBlogContext context)
        {
            var passwordHasher = new PasswordHasher<AppUser>();

            var rootAdminRoleId = Guid.NewGuid();
            if (!context.Roles.Any())
            {
                await context.Roles.AddAsync(new AppRole()
                {
                    Id = rootAdminRoleId,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    DisplayName = "Administrator"
                });
                await context.SaveChangesAsync();
            }

            if (!context.Users.Any())
            {
                var userId = Guid.NewGuid();
                var user = new AppUser()
                {
                    Id = userId,
                    LastName = "Phap",
                    FirstName = "Huynh",
                    Email = "admin@mf.com.vn",
                    NormalizedEmail = "ADMIN@MF.COM.VN",
                    UserName = "Admin",
                    NormalizedUserName = "ADMIN",
                    IsActive = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = false,
                    DateCreated = DateTime.Now
                };
                user.PasswordHash = passwordHasher.HashPassword(user, "Admin@12345");
                await context.Users.AddAsync(user);

                await context.UserRoles.AddAsync(new IdentityUserRole<Guid>()
                {
                    RoleId = rootAdminRoleId,
                    UserId = userId
                });
                await context.SaveChangesAsync();
            }
        }
    }
}
