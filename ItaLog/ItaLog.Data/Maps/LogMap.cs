using ItaLog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ItaLog.Data.Maps
{
    class LogMap : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.ToTable(nameof(Log));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .HasMaxLength(250)
                .HasColumnType("varchar(250)")
                .IsRequired();

            builder.Property(x => x.Detail)
               .HasMaxLength(1024)
               .HasColumnType("varchar(1024)")
               .IsRequired();

            builder.Property(x => x.UserErrorCode)
               .HasColumnType("int")
               .IsRequired();

            builder.Property(x => x.ApiUserId)
               .IsRequired();

            builder.HasOne(x => x.ApiUser)
                .WithMany(x => x.Logs);

            builder.Property(x => x.LevelId)
              .IsRequired();

            builder.HasOne(x => x.Level)
                .WithMany(x => x.Logs);

            builder.HasMany(x => x.Events)
                .WithOne(x => x.Log);
        }
    }
}
