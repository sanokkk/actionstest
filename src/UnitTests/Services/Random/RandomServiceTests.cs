using Actions.Instance.Services.Random;

namespace UnitTests.Services.Random;

[TestFixture]
public sealed class RandomServiceTests
{
    [Test]
    public void RandomHello_ShouldReturnCorrectString()
    {
        IRandomService target = new RandomHelloStringService();

        var result = target.GenerateRandomString();
        
        Assert.That(result, Is.Not.Null);
    }
}
