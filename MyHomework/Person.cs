using System.Text.Json.Serialization;

namespace MyHomework;

public class Person
{
    [JsonPropertyName("first")]

    public string FirstName { get; init; } = string.Empty;

    [JsonPropertyName("last")]
    public string LastName { get; init; } = string.Empty;

    [JsonPropertyName("city")]
    public string City { get; init; } = string.Empty;

    [JsonPropertyName("email")]
    public string Email { get; init; } = string.Empty;

    [JsonPropertyName("age")]
    public string Age { get; init; } = string.Empty;
}
