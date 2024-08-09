/// <summary>
/// We have provided you the code below for a proof of concept (PoC) console application that satisfies the following requirements:
/// - Reads random users from an API endpoint 5 times. 
/// - All responses from the API should be written to a file.
/// - All successful responses should be represented as a list of users with the following properties
///     - last name
///     - first name
///     - age
///     - city
///     - email
///   and be written to file as valid JSON.
/// 
/// There are now new requirements for this application, and we should like for you to update this console 
/// application to incorporate the following new requirements while satisfing the original requirements:
/// - Update this code so it follows .Net best practices and principles. The code should be extensible, reusable, and easy to test using Unit Tests.
/// - Add Unit tests.
/// - Make the the output file names configurable.
/// - Make the number of API calls configurable instead of 5.
/// - Add logging
/// </summary>
namespace MyHomework;

internal class Program
{
    static async Task Main(string[] args)
    {
        using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
        ILogger logger = factory.CreateLogger<Program>();
        logger.LogInformation("Logging for {Description}.", "MyHomework");

        Settings settings = new();

        logger.LogInformation("Testing {Num} people to {File}.", settings.NumberOfPeople, settings.OutputFilePath);
        PersonService service = new(settings.PersonUrl, logger);

        // Create a file
        StringBuilder sb = new();
        for (int num = 1; num <= settings.NumberOfPeople; ++num)
        {
            string jsonPerson = await service.GetNextPersonAsync();
            sb.AppendLine(jsonPerson);
        }
        string apiContent = sb.ToString();

        PersonStorageService storage = new(logger);

        // save raw API Content
        storage.SaveContent(settings.OutputFilePath, apiContent);

        // create people from raw API Content
        List<Person> people = storage.CreatePeople(settings.OutputFilePath);

        // save people content
        storage.SavePeople(settings.OutputFilePath, people);
    }
}
