using ItaLog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ItaLog.Data.Maps
{
    class EnvironmentMap : IEntityTypeConfiguration<Environment>
    {
        public void Configure(EntityTypeBuilder<Environment> builder)
        {
            builder.ToTable(nameof(Environment));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description)
               .HasMaxLength(20)
               .HasColumnType("varchar(20)")
               .IsRequired();
        }
    }
}
