namespace MyHomework;

public class PersonService
{
    readonly HttpClient? _httpClient = null;
    readonly string? _baseUrl = null;
    readonly ILogger? _logger = null;

    public PersonService(
        string? baseUrl,
        ILogger? logger = null,
        HttpClient? httpClient = null)
    {
        _baseUrl = baseUrl ?? "https://randomuser.me/api/";
        _httpClient = httpClient ?? new HttpClient();
        _logger = logger;
    }

    public async Task<string> GetNextPersonAsync()
    {
        _logger?.LogInformation("GetNextPersonAsync() called");
        var response = await _httpClient!.GetAsync(_baseUrl);
        Debug.Assert(response != null, $"API endpoint not found: {_baseUrl}");
        string jsonPerson = await response.Content.ReadAsStringAsync();
        Debug.Assert(jsonPerson.Length > 0, $"API failed with empty response: {_baseUrl}");
        _logger?.LogInformation("GetNextPersonAsync() w/ {Bytes} bytes.", jsonPerson.Length);
        return jsonPerson;
    }
}
