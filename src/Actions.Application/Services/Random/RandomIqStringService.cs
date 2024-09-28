namespace Actions.Instance.Services.Random;

public sealed class RandomIqStringService : IRandomService
{
    public string GenerateRandomString()
    {
        var rnd = new System.Random();

        return $"I have {rnd.Next()} IQ!";
    }
}
