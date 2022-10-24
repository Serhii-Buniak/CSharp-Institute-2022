namespace CityMicroService.DAL.Entities;

public class User
{
    public long Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Telephone { get; set; } = null!;
    public long CityId { get; set; }
    public City City { get; set; } = null!;
    public ICollection<Role> Roles { get; set; } = new List<Role>();
    public ICollection<Message> Messages { get; set; } = new List<Message>();
    public ICollection<Event> Events { get; set; } = new List<Event>();
}
