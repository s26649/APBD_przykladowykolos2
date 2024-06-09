using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD_przykladowykolos2.Entities.Config;

public class SailboatConfig : IEntityTypeConfiguration<Sailboat>
{
    public void Configure(EntityTypeBuilder<Sailboat> builder)
    {
        builder.HasKey(e => e.IdSailboat).HasName("Sailboat_pk");
        builder.Property(e => e.IdSailboat).UseIdentityColumn();
        builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Capacity).IsRequired();
        builder.Property(e => e.Description).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Price).IsRequired().HasColumnType("money");
        builder.HasOne(e => e.BoatStandard).WithMany(b => b.Sailboats).HasForeignKey(e => e.IdBoatStandard);
        builder.ToTable("Sailboat");
    }
}
