namespace DAL.Entities;

public class City
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public long CountryId { get; set; }
    public Country Country { get; set; } = null!;
    public ICollection<Event> Events { get; set; } = new List<Event>();
    public ICollection<User> Users { get; set; } = new List<User>();
}
