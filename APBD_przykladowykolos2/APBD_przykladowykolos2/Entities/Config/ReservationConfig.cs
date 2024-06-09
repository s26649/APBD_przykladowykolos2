using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD_przykladowykolos2.Entities.Config;

public class ReservationConfig : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.HasKey(e => e.IdReservation).HasName("Reservation_pk");
        builder.Property(e => e.IdReservation).UseIdentityColumn();
        builder.Property(e => e.DateFrom).IsRequired();
        builder.Property(e => e.DateTo).IsRequired();
        builder.Property(e => e.Capacity).IsRequired();
        builder.Property(e => e.NumOfBoats).IsRequired();
        builder.Property(e => e.Fulfilled).IsRequired();
        builder.Property(e => e.Price).IsRequired().HasColumnType("money");
        builder.Property(e => e.CancelReason).HasMaxLength(200);
        builder.HasOne(e => e.Client).WithMany(c => c.Reservations).HasForeignKey(e => e.IdClient);
        builder.HasOne(e => e.BoatStandard).WithMany(b => b.Reservations).HasForeignKey(e => e.IdBoatStandard);
        builder.ToTable("Reservation");
    }
}
