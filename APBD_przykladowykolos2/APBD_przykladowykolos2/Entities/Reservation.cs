namespace APBD_przykladowykolos2.Entities;

public class Reservation
{
    public int IdReservation { get; set; }
    public int IdClient { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public int IdBoatStandard { get; set; }
    public int Capacity { get; set; }
    public int NumOfBoats { get; set; }
    public bool Fulfilled { get; set; }
    public decimal Price { get; set; }
    public string CancelReason { get; set; }
    public virtual Client Client { get; set; }
    public virtual BoatStandard BoatStandard { get; set; }
    public virtual ICollection<Sailboat_Reservation> Sailboat_Reservations { get; set; } = new List<Sailboat_Reservation>();
}
