namespace MyHomework;

public class Settings
{
    public Settings()
    {
        string? valueNumberOfPeople = ConfigurationManager.AppSettings["NumberOfPeople"];
        if (int.TryParse(valueNumberOfPeople, out int numberOfPeople))
        {
            NumberOfPeople = numberOfPeople;
        }

        string? valueOutputFilePath = ConfigurationManager.AppSettings["OutputFilePath"];
        OutputFilePath = valueOutputFilePath ?? @"c:\temp\MyTest.txt";

        string? valuePersonUrl = ConfigurationManager.AppSettings["PersonUrl"];
        PersonUrl = valuePersonUrl ?? "https://randomuser.me/api";
    }


    public int NumberOfPeople { get; } = 5;
    public string OutputFilePath { get; }
    public string PersonUrl { get; }
}
