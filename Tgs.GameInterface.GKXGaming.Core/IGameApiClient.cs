using Tgs.GameInterface.GKXGaming.Core.Models;

namespace Tgs.GameInterface.GKXGaming.Core;

public interface IGameApiClient
{
    ValueTask<bool> GetOrderAsync(Uri apiUrl, string deskey, string md5key, string agentId, string orderId, CancellationToken cancellationToken = default);

    ValueTask<WithdrawResp> WithdrawAsync(Uri apiUrl, string deskey, string md5key, string agentId, string account, string orderId, decimal money, CancellationToken cancellationToken = default);

    ValueTask<DepositResp> DepositAsync(Uri apiUrl, string deskey, string md5key, string agentId, string account, string orderId, decimal money, CancellationToken cancellationToken = default);

    ValueTask<BalanceInfo> BalanceAsync(Uri apiUrl, string deskey, string md5key, string agentId, string account, CancellationToken cancellationToken = default);

    ValueTask<string> LoginAsync(Uri apiUrl, string deskey, string md5key, string agentId, string account, string ipAddress, string lineCode, CancellationToken cancellationToken = default);

    ValueTask<decimal> AgentBalanceAsync(Uri apiUrl, string deskey, string md5key, string agentId, CancellationToken cancellationToken = default);

    ValueTask LogoutAsync(Uri apiUrl, string deskey, string md5key, string agentId, string account, CancellationToken cancellationToken = default);
}
