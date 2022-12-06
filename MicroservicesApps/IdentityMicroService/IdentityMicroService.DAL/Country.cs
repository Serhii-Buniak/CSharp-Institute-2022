using System.ComponentModel.DataAnnotations;

namespace IdentityMicroService.BLL.DAL.Data;

public class Country
{
    [Key]
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<City> Cities { get; set; } = new List<City>();

    public override bool Equals(object? obj)
    {
        return obj is Country country &&
               Id == country.Id;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }
}