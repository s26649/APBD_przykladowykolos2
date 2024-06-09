namespace APBD_przykladowykolos2.Entities;

public class ClientCategory
{
    public int IdClientCategory { get; set; }
    public string Name { get; set; }
    public int DiscountPerc { get; set; }
    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
}