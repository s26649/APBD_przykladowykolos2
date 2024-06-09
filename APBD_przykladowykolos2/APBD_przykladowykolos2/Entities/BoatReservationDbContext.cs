using APBD_przykladowykolos2.Entities.Config;
using Microsoft.EntityFrameworkCore;

namespace APBD_przykladowykolos2.Entities;

public class BoatReservationDbContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<ClientCategory> ClientCategories { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Sailboat> Sailboats { get; set; }
    public DbSet<BoatStandard> BoatStandards { get; set; }
    public DbSet<Sailboat_Reservation> Sailboat_Reservations { get; set; }

    public BoatReservationDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClientConfig).Assembly);
    }
}
