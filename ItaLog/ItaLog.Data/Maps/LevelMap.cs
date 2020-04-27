using ItaLog.Data.Seed;
using ItaLog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ItaLog.Data.Maps
{
    class LevelMap : IEntityTypeConfiguration<Level>
    {
        public void Configure(EntityTypeBuilder<Level> builder)
        {
            builder.ToTable(nameof(Level));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description)
               .HasMaxLength(20)
               .HasColumnType("varchar(20)")
               .IsRequired();

            //builder.HasData(
            //        LevelSeed.GetData()
            //    );
        }
    }
}
