using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD_przykladowykolos2.Entities.Config;

public class Sailboat_ReservationConfig : IEntityTypeConfiguration<Sailboat_Reservation>
{
    public void Configure(EntityTypeBuilder<Sailboat_Reservation> builder)
    {
        builder.HasKey(e => new { e.IdSailboat, e.IdReservation });
        builder.HasOne(e => e.Sailboat).WithMany(s => s.Sailboat_Reservations).HasForeignKey(e => e.IdSailboat);
        builder.HasOne(e => e.Reservation).WithMany(r => r.Sailboat_Reservations).HasForeignKey(e => e.IdReservation);
        builder.ToTable("Sailboat_Reservation");
    }
}
