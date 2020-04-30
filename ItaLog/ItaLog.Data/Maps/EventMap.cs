using ItaLog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ItaLog.Data.Maps
{
    public class EventMap : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable(nameof(Event));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Detail)
               .HasMaxLength(1024)
               .HasColumnType("varchar(1024)")
               .IsRequired();

            builder.Property(x => x.ErrorDate)
                .HasColumnType("datetime")
                .IsRequired();
        }
    }
}
