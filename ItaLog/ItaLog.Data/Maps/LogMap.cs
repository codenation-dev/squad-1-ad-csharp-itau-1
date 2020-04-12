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

            builder.Property(x => x.Event)
                .IsRequired();

            builder.Property(x => x.Title)
                .HasMaxLength(250)
                .HasColumnType("varchar(250)")
                .IsRequired();

            builder.Property(x => x.Detail)
               .HasMaxLength(1024)
               .HasColumnType("varchar(1024)")
               .IsRequired();

            builder.Property(x => x.DateError)
               .HasColumnType("datetime")
               .IsRequired();

            builder.Property(x => x.UserId)
               .IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(x => x.Logs);

            builder.Property(x => x.Origin)
               .HasMaxLength(50)
               .HasColumnType("varchar(50)")
               .IsRequired();

            builder.Property(x => x.Origin)
               .HasMaxLength(50)
               .HasColumnType("varchar(50)")
               .IsRequired();

            builder.Property(x => x.Environment)
               .IsRequired();

            builder.Property(x => x.Level)
               .IsRequired();
        }
    }
}
