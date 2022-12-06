using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;

namespace IdentityMicroService.BLL.Clients.Http;

public class ImageClient : IImageClient
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public ImageClient(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task CreateImage(IFormFile image)
    {
        using MultipartFormDataContent form = new();
        using StreamContent streamContent = new(image.OpenReadStream());
        using ByteArrayContent content = new(await streamContent.ReadAsByteArrayAsync());

        content.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");

        form.Add(content, "file", image.FileName);

        using HttpResponseMessage response = await _httpClient.PostAsync(_configuration["ImageEndpoint"], form);

        string apiResponse = response.Content.ReadAsStringAsync().Result;

        //res = JsonConvert.DeserializeObject<List<RepositoryListResponseItem>>(apiResponse);

        Console.WriteLine(response.Content.ToString());



        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("-->> HttpResponseMessage PostAsync OK");
        }
        else
        {
            Console.WriteLine("-->> HttpResponseMessage PostAsync NOT OK");
            throw new Exception();
        }
    }
}