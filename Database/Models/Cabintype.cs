namespace Database.Models;

public partial class Cabintype
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; } = new List<Ticket>();
}
