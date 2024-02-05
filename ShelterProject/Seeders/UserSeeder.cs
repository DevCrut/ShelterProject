using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShelterProject.Data;
using ShelterProject.Models;
using System.Collections.Generic;

public static class UserSeeder
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
        {
            if (context.Roles.Any())
            {
                return;
            }
            context.Roles.AddRange(
                new IdentityRole { Id = "0740e234-58aa-4c2e-98d2-7f04f8119c5a", Name = "Admin", NormalizedName = "Admin".ToUpper() },
                new IdentityRole { Id = "d537a43d-3ea2-49d0-ad3b-e69435e44402", Name = "User", NormalizedName = "User".ToUpper() }
            );
            var hasher = new PasswordHasher<ApplicationUser>();
            context.Users.AddRange(
            new ApplicationUser
            {
                Id = "99b7b417-c05c-4a23-b6fb-f91d0106b5f3",
                // primary key
                UserName = "admin@test.com",
                EmailConfirmed = true,
                NormalizedEmail = "ADMIN@TEST.COM",
                Email = "admin@test.com",
                NormalizedUserName = "ADMIN@TEST.COM",
                PasswordHash = hasher.HashPassword(null, "Admin1!")
            },
            new ApplicationUser
            {
                Id = "2b59a18c-f8df-481a-8a7f-ab8a57ed7ea4",
                // primary key
                UserName = "user@test.com",
                EmailConfirmed = true,
                NormalizedEmail = "USER@TEST.COM",
                Email = "user@test.com",
                NormalizedUserName = "USER@TEST.COM",
                PasswordHash = hasher.HashPassword(null, "User1!")
}
            );
            // ASOCIEREA USER-ROLE
            context.UserRoles.AddRange(
                new IdentityUserRole<string>
                {
                    RoleId = "0740e234-58aa-4c2e-98d2-7f04f8119c5a",
                    UserId = "99b7b417-c05c-4a23-b6fb-f91d0106b5f3"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "d537a43d-3ea2-49d0-ad3b-e69435e44402",
                    UserId = "2b59a18c-f8df-481a-8a7f-ab8a57ed7ea4"
                }
            );
            context.SaveChanges();
        }
    }
}