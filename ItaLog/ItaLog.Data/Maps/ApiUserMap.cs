using ItaLog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ItaLog.Data.Maps
{
    class ApiUserMap : IEntityTypeConfiguration<ApiUser>
    {
        public void Configure(EntityTypeBuilder<ApiUser> builder)
        {
            builder.ToTable(nameof(ApiUser));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserToken)
                .IsRequired();

            builder.Property(x => x.Name)
                .HasMaxLength(250)
                .HasColumnType("varchar(250)")
                .IsRequired();

            builder.Property(x => x.UserName)
                .HasMaxLength(250)
                .HasColumnType("varchar(250)")
                .IsRequired();

            builder.Property(x => x.NormalizedUserName)
                .HasMaxLength(250)
                .HasColumnType("varchar(250)");

            builder.Property(x => x.Email)
               .HasMaxLength(250)
               .HasColumnType("varchar(250)")
               .IsRequired();

            builder.Property(x => x.Password)
               .HasColumnType("varchar(max)")
               .IsRequired();
        }
    }
}
