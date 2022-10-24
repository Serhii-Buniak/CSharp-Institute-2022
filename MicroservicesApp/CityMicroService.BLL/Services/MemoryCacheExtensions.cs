using CityMicroService.DAL.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace CityMicroService.BLL.Services;

public static class MemoryCacheExtensions
{
    private const string CategoriesKey = "categories";
    private const string CitiesKey = "cities";

    public static IEnumerable<Category> SetCategories(this IMemoryCache memoryCache, IEnumerable<Category> categories, int seconds)
    {
        return memoryCache.Set(CategoriesKey, categories, TimeSpan.FromSeconds(seconds));
    }   
    
    public static IEnumerable<Category> GetCategories(this IMemoryCache memoryCache)
    {
        return memoryCache.Get<IEnumerable<Category>>(CategoriesKey);
    }    
    
    public static IEnumerable<City> SetCities(this IMemoryCache memoryCache, IEnumerable<City> cities, int seconds)
    {
        return memoryCache.Set(CitiesKey, cities, TimeSpan.FromSeconds(seconds));
    }   
    
    public static IEnumerable<City> GetCities(this IMemoryCache memoryCache)
    {
        return memoryCache.Get<IEnumerable<City>>(CitiesKey);
    }
}
