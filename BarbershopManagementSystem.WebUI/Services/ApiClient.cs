using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Newtonsoft.Json;
using System.Text;

namespace BarbershopManagementSystem.WebUI.Services;

public class ApiClient
{
    private readonly HttpClient _client;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ApiClient(IConfiguration configuration,
        IHttpContextAccessor httpContextAccessor)
    {
        _client = new HttpClient();

        _client.BaseAddress = new Uri("https://localhost:7275/api/");
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<T> GetAsync<T>(string url) where T : class
    {
        var response = await _client.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<T>(json);

        if (result is null)
        {
            throw new JsonSerializationException($"Unable to deserialize response from {url}.");
        }

        return result;
    }

    public async Task<Stream> GetAsStreamAsync(string url)
    {
        var response = await _client.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var stream = await response.Content.ReadAsStreamAsync();

        return stream;
    }

    public async Task<TResult> PostAsync<TResult, TBody>(string url, TBody body)
        where TBody : class
    {
        var response = await _client.PostAsJsonAsync(url, body);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<TResult>(json);

        if (result is null)
        {
            throw new JsonSerializationException($"Unable to deserialize response from {url}.");
        }

        return result;
    }

    public async Task PutAsync<TBody>(string url, TBody body)
    {
        var response = await _client.PutAsJsonAsync(url, body);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteAsync(string url, int id)
    {
        var response = await _client.DeleteAsync($"{url}/{id}");
        response.EnsureSuccessStatusCode();
    }
}
