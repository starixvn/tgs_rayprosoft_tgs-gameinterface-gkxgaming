using Tgs.GameInterface.GKXGaming.Core.Models;

namespace Tgs.GameInterface.GKXGaming.Core;

public interface IGameRecordApiClient
{
    IAsyncEnumerable<GameRecordInfo> GameRecordAsync(Uri apiUrl, string deskey, string md5key, string agentId, DateTimeOffset startTime, DateTimeOffset endTime, int retrySeconds = 10, CancellationToken cancellationToken = default);
}
