namespace MyHomework.Tests;

public class PersonStorageServiceTest
{
    PersonStorageService _service;

    [SetUp]
    public void Setup()
    {
        _service = new PersonStorageService();
    }

    [Test]
    public void PersonStorageService_Create_Test()
    {
        Assert.IsNotNull(_service);
        Assert.Pass();
    }

    [Test]
    public void PersonStorageService_SaveContent_Test()
    {
        Assert.IsNotNull(_service);
        string filepath = Path.GetTempFileName();
        string toWrite = "hello test";
        _service.SaveContent(filepath,toWrite);
        string read = File.ReadAllText(filepath);
        Assert.IsTrue(toWrite.Length == read.Length);
        Assert.IsTrue(toWrite == read);
        File.Delete(filepath);
        Assert.Pass();
    }

    [Test]
    public void PersonStorageService_SavePeople_Empty_Test()
    {
        Assert.IsNotNull(_service);
        string filepath = Path.GetTempFileName();
        _service.SavePeople(filepath, new());
        string read = File.ReadAllText(filepath);
        Assert.IsTrue(2 == read.Length); 
        Assert.IsTrue("[]" == read);
        File.Delete(filepath);
        Assert.Pass();
    }


    [Test]
    public void PersonStorageService_CreatePeople_Test()
    {
        Assert.IsNotNull(_service);
        List<Person> people = _service.CreatePeople("example.json");
        Assert.IsNotNull(people);
        Assert.IsTrue(people.Count == 1);
        Person person = people.First();
        Assert.IsTrue(person.Age == "76");
        Assert.IsTrue(person.City == "Blumenau");
        Assert.IsTrue(person.Email == "indalecio.araujo@example.com");
        Assert.IsTrue(person.FirstName == "Indalécio");
        Assert.IsTrue(person.LastName == "Araújo");
        Assert.Pass();
    }
}
