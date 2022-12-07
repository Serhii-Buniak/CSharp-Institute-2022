using AutoMapper;
using IdentityMicroService.BLL.DAL.Data;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

namespace IdentityMicroService.BLL.Subscribers.Processor;

public class CountryEventProcessor : ICountryEventProcessor
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly IMapper _mapper;

    public CountryEventProcessor(IServiceScopeFactory scopeFactory, IMapper mapper)
    {
        _scopeFactory = scopeFactory;
        _mapper = mapper;
    }

    public void ProcessEvent(string message)
    {
        var eventType = DetermineEvent(message);

        switch (eventType)
        {
            case CountryEventType.Create:
                AddCountry(message);
                break;
            case CountryEventType.Update:
                UpdateCountry(message);
                break;
            case CountryEventType.Delete:
                DeleteCountry(message);
                break;
            default:
                break;
        }

    }

    private void AddCountry(string countrySubscribedMessage)
    {
        using IServiceScope scope = _scopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var countrySubscribed = JsonSerializer.Deserialize<CountrySubscribed>(countrySubscribedMessage);
        var country = _mapper.Map<Country>(countrySubscribed);

        try
        {
            if (!context.Countries.Any(c => c.Id == country.Id))
            {
                context.Countries.Add(country);
                context.SaveChanges();
                Console.WriteLine("--> Country added!");
            }
            else
            {
                Console.WriteLine("--> Country already exist...");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"--> Could not add Country to DB {ex.Message}");

        }
    }

    private void UpdateCountry(string countrySubscribedMessage)
    {
        using IServiceScope scope = _scopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var countrySubscribed = JsonSerializer.Deserialize<CountrySubscribed>(countrySubscribedMessage);
        var country = _mapper.Map<Country>(countrySubscribed);

        try
        {
            if (context.Countries.Any(c => c.Id == country.Id))
            {
                context.Countries.Update(country);
                context.SaveChanges();
                Console.WriteLine("--> Country updated!");
            }
            else
            {
                Console.WriteLine("--> Country do not exist...");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"--> Could not update Country to DB {ex.Message}");
        }
    }

    private void DeleteCountry(string countrySubscribedMessage)
    {
        using IServiceScope scope = _scopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var countrySubscribed = JsonSerializer.Deserialize<CountrySubscribed>(countrySubscribedMessage);
        var country = _mapper.Map<Country>(countrySubscribed);

        try
        {
            if (context.Countries.Any(c => c.Id == country.Id))
            {
                context.Countries.Remove(country);
                context.SaveChanges();
                Console.WriteLine("--> Country deleted!");
            }
            else
            {
                Console.WriteLine("--> Country do not exist...");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"--> Could not delete Country to DB {ex.Message}");

        }
    }


    private static CountryEventType DetermineEvent(string notifactionMessage)
    {
        Console.WriteLine("--> Determining Event");

        var eventType = JsonSerializer.Deserialize<ModelPublished>(notifactionMessage)!;

        switch (eventType.Event)
        {
            case "Country_Create":
                Console.WriteLine("--> Country Create Event Detected");
                return CountryEventType.Create;
            case "Country_Update":
                Console.WriteLine("--> Country Update Event Detected");
                return CountryEventType.Update;
            case "Country_Delete":
                Console.WriteLine("--> Country Delete Event Detected");
                return CountryEventType.Delete;
            default:
                Console.WriteLine("--> Could not determine the event type");
                return CountryEventType.Undetermined;
        }
    }


}

enum CountryEventType
{
    Create,
    Update,
    Delete,
    Undetermined
}