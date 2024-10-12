namespace HealthCheck.Services;

internal class HttpWorker : IHttpWorker
{
    private readonly HttpClient _httpClient = new HttpClient();
    private readonly ILogger _logger;

    internal HttpWorker(ILogger logger)
    {
        _logger = logger;
    }

    public async Task<Result> GetResultAsync(string requestUri)
    {
        try
        {
            var response = await _httpClient.GetAsync(requestUri);
            if (response.IsSuccessStatusCode)
            {
                _logger.LogInformation("Success response status code '{0}.", response.StatusCode);
                return Result.Ok();
            }
            {
                _logger.LogWarning("Fail response status code '{0}.", response.StatusCode);
                return Result.Fail();
            }
        }
        catch (HttpRequestException ex)
        {
            _logger.LogWarning("Request failed '{0}'.", ex.Message);
            return Result.Fail();
        }
        catch (Exception ex)
        {
            _logger.LogWarning("Request failed '{0}'.", ex);
            return Result.Fail();
        }
    }
}
