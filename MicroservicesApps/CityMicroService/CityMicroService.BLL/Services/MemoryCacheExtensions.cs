using CityMicroService.DAL.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace CityMicroService.BLL.Services;

public static class MemoryCacheExtensions
{
    private const string CitiesKey = "cities";
    private const string CountriesKey = "countries";

    public static IEnumerable<City> SetCities(this IMemoryCache memoryCache, IEnumerable<City> cities, int seconds)
    {
        return memoryCache.Set(CitiesKey, cities, TimeSpan.FromSeconds(seconds));
    }   
    
    public static IEnumerable<City> GetCities(this IMemoryCache memoryCache)
    {
        return memoryCache.Get<IEnumerable<City>>(CitiesKey);
    }   
    
    public static IEnumerable<Country> SetCountries(this IMemoryCache memoryCache, IEnumerable<Country> cities, int seconds)
    {
        return memoryCache.Set(CountriesKey, cities, TimeSpan.FromSeconds(seconds));
    }   
    
    public static IEnumerable<Country> GetCountries(this IMemoryCache memoryCache)
    {
        return memoryCache.Get<IEnumerable<Country>>(CountriesKey);
    }
}
