using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD_przykladowykolos2.Entities.Config;

public class BoatStandardConfig : IEntityTypeConfiguration<BoatStandard>
{
    public void Configure(EntityTypeBuilder<BoatStandard> builder)
    {
        builder.HasKey(e => e.IdBoatStandard).HasName("BoatStandard_pk");
        builder.Property(e => e.IdBoatStandard).UseIdentityColumn();
        builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Level).IsRequired();
        builder.ToTable("BoatStandard");
    }
}
