using ItaLog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ItaLog.Data.Maps
{
    class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Token)
                .IsRequired();

            builder.Property(x => x.Name)
                .HasMaxLength(250)
                .HasColumnType("varchar(250)")
                .IsRequired();

            builder.Property(x => x.Email)
               .HasMaxLength(250)
               .HasColumnType("varchar(250)")
               .IsRequired();

            builder.Property(x => x.Password)
               .HasMaxLength(50)
               .HasColumnType("varchar(50)")
               .IsRequired();
        }
    }
}
