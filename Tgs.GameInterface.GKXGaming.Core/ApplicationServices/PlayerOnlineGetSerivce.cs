using Tgs.ServiceUtility;

namespace Tgs.GameInterface.GKXGaming.Core.ApplicationServices;

public class PlayerOnlineGetSerivce(IGameApiClient client) : IGetService<PlayerOnlineQuery, bool>
{
	public async ValueTask<bool> GetAsync(PlayerOnlineQuery query, CancellationToken cancellationToken = default)
	{
		var info = await client
			.BalanceAsync(
			apiUrl: query.ApiUrl,
			deskey: query.Deskey,
			md5key: query.MD5key,
			agentId: query.AgentId,
			account: query.PlayerCode,
			cancellationToken: cancellationToken)
			.ConfigureAwait(false);

		return info.Online;
	}
}
