using ItaLog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ItaLog.Data.Maps
{
    public class UserRoleMap : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable(nameof(UserRole));

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
