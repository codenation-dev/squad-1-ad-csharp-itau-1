using ItaLog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItaLog.Data.Maps
{
    public class EventMap : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable(nameof(Event));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ErrorDate)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(x => x.Origin)
                .HasMaxLength(20)
                .HasColumnType("varchar(20)")
                .IsRequired();

            builder.Property(x => x.Archived)
                .IsRequired();

        }
    }
}
