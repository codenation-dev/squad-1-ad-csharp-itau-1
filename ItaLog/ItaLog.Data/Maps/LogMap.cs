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

            builder.Property(x => x.Origin)
                .HasMaxLength(250)
                .HasColumnType("varchar(250)")
                .IsRequired();

            builder.Property(x => x.Archived)
                .IsRequired();

            builder.Property(x => x.ApiUserId)
               .IsRequired();

            builder.Property(x => x.LevelId)
              .IsRequired();

            builder.Property(x => x.EnvironmentId)
              .IsRequired();

            builder.Ignore(x => x.EventsCount);                


            builder.HasOne(x => x.ApiUser)
                .WithMany(x => x.Logs)
                .HasForeignKey(x => x.ApiUserId);

            builder.HasOne(x => x.Level)
                .WithMany(x => x.Logs)
                .HasForeignKey(x => x.LevelId);

            builder.HasOne(x => x.Environment)
                .WithMany(x => x.Logs)
                .HasForeignKey(x => x.EnvironmentId);

            builder.HasMany(x => x.Events)
                .WithOne(x => x.Log);
        }
    }
}
