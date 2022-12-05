using Microsoft.Extensions.Caching.Memory;
using static CityMicroService.Test.BLL.Services.CityServiceTestHelper;

namespace CityMicroService.Test.BLL.Services;

public class CityServiceTest
{
    protected readonly Mock<IRepositoryWrapper> repoWrapper;
    protected readonly Mock<ICityRepository> cityRepo;
    protected readonly Mock<ICountryRepository> countryRepo;
    protected readonly Mock<IMapper> mapper;
    protected readonly Mock<IMemoryCache> cache;

    protected readonly CityService cityService;


    public CityServiceTest()
    {
        repoWrapper = new();
        cityRepo = new();
        countryRepo = new();
        mapper = new();
        cache = new();

        repoWrapper.Setup(prop => prop.CityRepository).Returns(cityRepo.Object);
        repoWrapper.Setup(prop => prop.CountryRepository).Returns(countryRepo.Object);

        cityService = new(
            repositoryWrapper: repoWrapper.Object,
            mapper: mapper.Object,
            memoryCache: cache.Object
        );
    }

    [Fact]
    public async Task GetAllAsync_WasCached_ReturnCityDtos()
    {
        cache.Setup(prop => prop.GetCities()).Returns(GetCities);
        mapper.Setup(prop => prop.Map<IEnumerable<CityDTO>>(It.IsAny<IEnumerable<City>>())).Returns(GetCitiesDTOs);

        IEnumerable<CityDTO> cityDTOs = await cityService.GetAllAsync();

        Assert.Equal(GetCitiesDTOs().Count(), cityDTOs.Count());
    }
}
