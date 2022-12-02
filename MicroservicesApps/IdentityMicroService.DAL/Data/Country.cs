using System.ComponentModel.DataAnnotations;

namespace IdentityMicroService.DAL.Data;

public class Country
{
    [Key]
    public long Id { get; set; }
    public long ExternalId { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<City> Cities { get; set; } = new List<City>();
}