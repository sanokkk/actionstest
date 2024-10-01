namespace Actions.Instance.Services.Random;

public sealed class HeightRandomService : IRandomService
{
    public string GenerateRandomString()
    {
        var rnd = new System.Random();

        return $"I have {rnd.Next(0, 1000)} cm height";
    }
}
