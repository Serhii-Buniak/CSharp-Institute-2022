using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace IdentityMicroService.BLL.DAL.Data;

public class City
{
    [Key]
    public long Id { get; set; }
    public long ExternalId { get; set; }
    public string Name { get; set; } = null!;
    public long CountryId { get; set; }
    public Country Country { get; set; } = null!;
}
