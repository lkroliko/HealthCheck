// Ignore Spelling: App

using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HealthCheck.EndToEndTests.Common;
public class TestApp
{
    private readonly TestContainer _container;
    private readonly HttpClient _httpClient = new();
    private readonly JsonSerializerOptions _options = new JsonSerializerOptions()
    {
        PropertyNameCaseInsensitive = true,
    };

    public TestApp(TestContainer container)
    {
        _container = container;

        _options.Converters.Add(new JsonStringEnumConverter());
        _httpClient.BaseAddress = new Uri($"http://localhost:{_container.Port}");
    }

    public async Task SetHealthStatusAsync(HealthStatus status)
    {
        var response = await _httpClient.GetAsync(status.ToString().ToLower());

        if (response.IsSuccessStatusCode == false)
            throw new Exception($"Unable to set app health status. Status code is '{response.StatusCode}'.");

        var currentStatus = await GetHealthAsync();

        if (status != currentStatus)
            throw new Exception($"Unable to set app health status. Status is '{currentStatus}'.");

        await Task.Delay(2000);
    }

    public async Task<HealthStatus> GetHealthAsync()
    {
        var message = await _httpClient.GetAsync("hc");
        var response = await message.Content.ReadFromJsonAsync<StatusResponse>(_options);
        return response!.Status;
    }

    private class StatusResponse
    {
        public required HealthStatus Status { get; set; }
    }
}
