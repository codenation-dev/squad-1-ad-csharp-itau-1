using ItaLog.Data.Seeds;
using ItaLog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ItaLog.Data.Maps
{
    public class ApiRoleMap : IEntityTypeConfiguration<ApiRole>
    {
        public void Configure(EntityTypeBuilder<ApiRole> builder)
        {
            builder.ToTable(nameof(ApiRole));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.HasData(RoleSeed.GetData());
        }
    }
}
