using EventMicroService.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Text;
using Newtonsoft.Json;
using System.Text.Json;
using EventMicroService.Application.Common.Interfaces;
using EventMicroService.Application.Common.Dtos;
using System.Net.Http.Headers;
using MediatR;
using Microsoft.Net.Http.Headers;

namespace EventMicroService.Infrastructure.Clients.Http;

public class GalleryClient : IGalleryClient
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public GalleryClient(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient; 
        _configuration = configuration;
    }

    public async Task<Gallery?> CreateGalleryAsync(CreateGalleryDto createGallery)
    {
        const string appJson = "application/json";

        StringContent content = new(
            content: System.Text.Json.JsonSerializer.Serialize(createGallery),
            encoding: Encoding.UTF8,
            mediaType: appJson
        );

        HttpResponseMessage response = await _httpClient.PostAsync(_configuration["GalleryEndpoint"], content);

        string apiResponse = response.Content.ReadAsStringAsync().Result;

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("-->> HttpResponseMessage PostAsync OK");
        }
        else
        {
            Console.WriteLine("-->> HttpResponseMessage PostAsync NOT OK");
        }

        var gallery = JsonConvert.DeserializeObject<Gallery>(apiResponse);

        return gallery;
    }
}
