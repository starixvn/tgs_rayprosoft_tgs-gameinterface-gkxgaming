using System.Web;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.GKXGaming.Core.ApplicationServices;

public class GameUrlGetService(
    IGameApiClient client) : IGetService<GameUrlQuery, string>
{
    public async ValueTask<string> GetAsync(
        GameUrlQuery query,
        CancellationToken cancellationToken = default)
    {
        var url = await client.LoginAsync(
            apiUrl: query.ApiUrl,
            deskey: query.Deskey,
            md5key: query.MD5key,
            agentId: query.AgentId,
            account: query.PlayerCode,
            ipAddress: query.IpAddress,
            lineCode: query.BrandCode,
            cancellationToken: cancellationToken)
        .ConfigureAwait(false);

        var gameurl = new Uri(url);

        var uriBuilder = new UriBuilder(new Uri(url));
        var queryItems = HttpUtility.ParseQueryString(gameurl.Query);
        queryItems["gameId"] = query.ExternalGameId;
        queryItems["lang"] = query.Lang;

        uriBuilder.Query = queryItems.ToString();

        return uriBuilder.ToString();
    }
}
