using ItaLog.Data.Seeds;
using ItaLog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ItaLog.Data.Maps
{
    class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));

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

            builder.Property(x => x.CreateDate)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(x => x.LastUpdateDate)
                .HasColumnType("datetime")
                .IsRequired();

            //builder.HasData(
            //        UserSeed.GetData()
            //    );
        }
    }
}
