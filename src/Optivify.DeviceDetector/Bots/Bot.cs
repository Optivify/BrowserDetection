namespace Optivify.DeviceDetector.Bots;

public class Bot(string botType) : IBot
{
    public string BotType { get; } = botType;

    public override string ToString()
    {
        return BotType;
    }
}
