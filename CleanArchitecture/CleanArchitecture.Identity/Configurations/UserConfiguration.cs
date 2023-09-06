using CleanArchitecture.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                    new ApplicationUser
                    {
                        Id = "86b9abee-6a35-44e6-9ade-3ad2a2625210",
                        Email = "admin@localhost.com",
                        NormalizedEmail = "admin@localhost.com",
                        Nombre = "Vaxi",
                        Apellidos = "Drez",
                        UserName = "vaxidrez",
                        NormalizedUserName = "vaxidrez",
                        PasswordHash = hasher.HashPassword(null, "VaxiDrez2025$"),
                        EmailConfirmed = true
                    },
                    new ApplicationUser
                    {
                        Id = "d861344f-402c-489b-91d4-39cfe2acc7b7",
                        Email = "juanperez@localhost.com",
                        NormalizedEmail = "juanperez@localhost.com",
                        Nombre = "Juan",
                        Apellidos = "Perez",
                        UserName = "juanperez",
                        NormalizedUserName = "juanperez",
                        PasswordHash = hasher.HashPassword(null, "VaxiDrez2025$"),
                        EmailConfirmed = true
                    }
                );
        }
    }
}
