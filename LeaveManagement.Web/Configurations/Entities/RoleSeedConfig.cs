using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagement.Web.Configurations.Entities
{
    /// <summary>
    /// creates a role seed on model create
    /// </summary>
    internal class RoleSeedConfig : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "4cge9abc - 6741 - 473f - 907e - 15e96893788e",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                },
                new IdentityRole
                {
                    Id = "4cge7abc - 7641 - 473f - 907e - 15e88893788e",
                    Name = "User",
                    NormalizedName = "USER"
                }
                );
        }
    }
}