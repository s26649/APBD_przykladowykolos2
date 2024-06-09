namespace APBD_przykladowykolos2.Entities;

public class BoatStandard
{
    public int IdBoatStandard { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }
    public virtual ICollection<Sailboat> Sailboats { get; set; } = new List<Sailboat>();
    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
