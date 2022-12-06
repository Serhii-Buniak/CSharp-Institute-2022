using IdentityMicroService.BLL.DAL.Data;

namespace IdentityMicroService.BLL.Clients.Grpc;

public interface ICityClient
{
    IEnumerable<City> GetAllCities();
    IEnumerable<Country> GetAllCountries();
}