namespace Actions.Instance.Services.Random;

public sealed class RandomHelloStringService : IRandomService
{
    public string GenerateRandomString()
    {
        var rnd = new System.Random();

        return $"Hello with {rnd.Next(0, 1000)} number";
    }
}
