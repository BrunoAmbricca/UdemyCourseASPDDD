using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configurations
{
    internal class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                    new IdentityUserRole<string>
                    {
                        RoleId = "8b23f952-7241-4923-b20f-360459716bf7",
                        UserId = "86b9abee-6a35-44e6-9ade-3ad2a2625210"
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId = "da14984b-09ef-462a-8357-d3de3faa4f3a",
                        UserId = "d861344f-402c-489b-91d4-39cfe2acc7b7"
                    }
                );
        }
    }
}
