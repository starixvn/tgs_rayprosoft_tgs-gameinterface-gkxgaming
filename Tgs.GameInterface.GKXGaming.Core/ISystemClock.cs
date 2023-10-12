namespace Tgs.GameInterface.GKXGaming.Core;

public interface ISystemClock
{
    DateTimeOffset CurrentTime { get; }
}
