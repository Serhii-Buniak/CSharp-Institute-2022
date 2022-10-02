namespace DAL.Entities;

public class Category
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<Event> Events { get; set; } = new List<Event>();
}