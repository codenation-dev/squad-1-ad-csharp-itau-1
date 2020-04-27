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

            builder.HasKey(x => new { x.UserId, x.RoleId });

            builder.HasOne(au => au.User)
                .WithMany(ur => ur.UserRoles)
                .HasForeignKey(au => au.UserId);

            builder.HasOne(ar => ar.Role)
                .WithMany(ur => ur.UserRoles)
                .HasForeignKey(ar => ar.RoleId);

            builder.Property(x => x.Id)
                .UseIdentityColumn();
        }
    }
}
