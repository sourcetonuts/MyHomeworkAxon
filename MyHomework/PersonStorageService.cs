using System.Text.Json;

namespace MyHomework;

public class PersonStorageService
{
    readonly ILogger? _logger;

    public PersonStorageService(ILogger? logger = null)
    {
        _logger = logger;
    }

    public void SaveContent(string filepath, string content)
    {
        File.WriteAllText(filepath, content);
        _logger?.LogInformation("Wrote {Bytes} bytes to file {FilePath}", content.Length, filepath);
    }

    public void SavePeople(string filepath, List<Person> people)
    {
        string jsonPeople = JsonSerializer.Serialize(people);
        File.WriteAllText(filepath, jsonPeople);
        _logger?.LogInformation("Wrote {Number} people to file {FilePath}", people.Count, filepath);
    }

    public List<Person> CreatePeople(string filepath)
    {
        List<Person> people = new();
        using StreamReader reader = new(filepath);
        for (int num = 1; ; ++num)
        {
            string? line = reader?.ReadLine();

            // break on empty line
            if (string.IsNullOrEmpty(line))
                break;
            JObject obj = JObject.Parse(line);
            string lastname = obj["results"][0]["name"]["last"].ToString();
            string firstname = obj["results"][0]["name"]["first"].ToString();
            string city = obj["results"][0]["location"]["city"].ToString();
            string email = obj["results"][0]["email"].ToString();
            string age = obj["results"][0]["dob"]["age"].ToString();
            Person person = new()
            {
                FirstName = firstname,
                LastName = lastname,
                City = city,
                Email = email,
                Age = age,
            };
            people.Add(person);
        }

        _logger?.LogInformation("Parsed {Number} people", people.Count);
        return people;
    }
}
