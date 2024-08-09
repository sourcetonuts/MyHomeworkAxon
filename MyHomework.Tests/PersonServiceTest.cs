namespace MyHomework.Tests;

public class PersonServiceTest
{
    PersonService _service;

    [SetUp]
    public void Setup()
    {
        _service = new PersonService("https://randomuser.me/api");
    }

    [Test]
    public void PersonService_Create_Test()
    {
        Assert.IsNotNull(_service);
        Assert.Pass();
    }


    [Test]
    public async Task PersonService_GetPerson_Test()
    {
        Assert.IsNotNull(_service);
        var jsonPerson = await _service.GetNextPersonAsync();
        Assert.IsNotNull(jsonPerson);
        Assert.IsTrue(jsonPerson.Length > 0);
        Assert.Pass();
    }

}