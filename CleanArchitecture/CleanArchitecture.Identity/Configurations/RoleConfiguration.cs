using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Identity.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                    new IdentityRole
                    {
                        Id = "8b23f952-7241-4923-b20f-360459716bf7",
                        Name = "Administrator",
                        NormalizedName = "ADMINISTRATOR",
                    },
                    new IdentityRole
                    {
                        Id = "da14984b-09ef-462a-8357-d3de3faa4f3a",
                        Name = "Operator",
                        NormalizedName = "OPERATOR",
                    }
                );
        }
    }
}
