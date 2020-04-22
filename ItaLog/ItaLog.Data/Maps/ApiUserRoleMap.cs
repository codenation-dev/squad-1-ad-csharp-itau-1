using ItaLog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ItaLog.Data.Maps
{
    public class ApiUserRoleMap : IEntityTypeConfiguration<ApiUserRole>
    {
        public void Configure(EntityTypeBuilder<ApiUserRole> builder)
        {
            builder.ToTable(nameof(ApiUserRole));

            builder.HasKey(x => new { x.ApiUserId, x.ApiRoleId });

            builder.HasOne(au => au.ApiUser)
                .WithMany(ur => ur.UserRoles)
                .HasForeignKey(au => au.ApiUserId);

            builder.HasOne(ar => ar.ApiRole)
                .WithMany(ur => ur.UserRoles)
                .HasForeignKey(ar => ar.ApiRoleId);

            builder.Property(x => x.Id)
                .UseIdentityColumn();
        }
    }
}
