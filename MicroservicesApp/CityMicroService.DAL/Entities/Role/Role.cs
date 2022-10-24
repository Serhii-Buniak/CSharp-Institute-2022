namespace CityMicroService.DAL.Entities;

public class Role
{ 
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<User> Users { get; set; } = new List<User>();
}