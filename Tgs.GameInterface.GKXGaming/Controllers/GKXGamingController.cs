using Microsoft.AspNetCore.Mvc;
using Tgs.GameInterface.GKXGaming.Core.ApplicationServices;
using Tgs.ServiceUtility;

namespace Tgs.GameInterface.GKXGaming.Controllers;

[Route("[controller]")]
[ApiController]
public class GKXGamingController : ControllerBase
{
	/// <summary>
	/// Funds the in asynchronous.
	/// </summary>
	/// <param name="service">The service.</param>
	/// <param name="source">The source.</param>
	/// <returns></returns>
	/// <remarks>
	/// <b>Example</b><br />
	///
	///     Post
	///
	///         {
	///             "apiUrl": " https://wc-api.orz16.com/",
	///             "deskey": "03CFE0179704BCDF",
	///             "mD5key": "337B01054C6FA208",
	///             "agentId": "60073",
	///             "playerCode":"4uh3pdl0lcii",
	///             "orderId": "60073202310120338068944uh3pdl0lcii"
	///             "amount": 1
	///         }
	/// </remarks>
	[HttpPost("fund/in", Name = "FundIn")]
	public ValueTask<FundResult> FundInAsync(
		[FromServices] IGetService<FundInQuery, FundResult> service,
		FundInQuery source)
		=> service.GetAsync(
			query: source,
			cancellationToken: HttpContext.RequestAborted);

	/// <summary>
	/// Funds the out asynchronous.
	/// </summary>
	/// <param name="service">The service.</param>
	/// <param name="source">The source.</param>
	/// <returns></returns>
	/// <remarks>
	/// <b>Example</b><br />
	///
	///     Post
	///
	///         {
	///             "apiUrl": " https://wc-api.orz16.com/",
	///             "deskey": "03CFE0179704BCDF",
	///             "mD5key": "337B01054C6FA208",
	///             "agentId": "60073",
	///             "playerCode":"4uh3pdl0lcii",
	///             "orderId": "6007320202310120336009404uh3pdl0lcii",
	///             "amount": 1
	///         }
	/// </remarks>
	[HttpPost("fund/out", Name = "FundOut")]
	public ValueTask<FundResult> FundOutAsync(
		[FromServices] IGetService<FundOutQuery, FundResult> service,
		FundOutQuery source)
		=> service.GetAsync(
			query: source,
			cancellationToken: HttpContext.RequestAborted);

	/// <summary>
	/// Funds the status asynchronous.
	/// </summary>
	/// <param name="service">The service.</param>
	/// <param name="source">The source.</param>
	/// <returns></returns>
	/// <remarks>
	/// <b>Example</b><br />
	///
	///     Post
	///
	///         {
	///             "apiUrl": " https://wc-api.orz16.com/",
	///             "deskey": "03CFE0179704BCDF",
	///             "mD5key": "337B01054C6FA208",
	///             "agentId": "60073",
	///             "orderId": "60073202310111727221424uh3pdl0lcii"
	///         }
	/// </remarks>
	[HttpPost("fund/Status", Name = "FundStatus")]
	public ValueTask<bool> FundStatusAsync(
		[FromServices] IGetService<FundStatusQuery, bool> service,
		FundStatusQuery source)
		=> service.GetAsync(
			query: source,
			cancellationToken: HttpContext.RequestAborted);

	/// <summary>
	/// Games the record asynchronous.
	/// </summary>
	/// <param name="service">The service.</param>
	/// <param name="source">The source.</param>
	/// <returns></returns>
	/// <remarks>
	/// <b>Example</b><br />
	///
	///     Post
	///
	///         {
	///             "apiUrl": "https://wc-record.orz16.com/",
	///             "deskey": "03CFE0179704BCDF",
	///             "mD5key": "337B01054C6FA208",
	///             "agentId": "60073",
	///             "startTime": "2023-07-26T11:50:00+08:00",
	///             "endTime": "2023-07-26T12:00:00+08:00"
	///         }
	/// </remarks>
	[HttpPost("game/wager")]
	public IAsyncEnumerable<GameWagerResult> GameRecordAsync(
		[FromServices] IQueryService<GameWagerQuery, GameWagerResult> service,
		GameWagerQuery source)
		=> service.QueryAsync(
			query: source,
			cancellationToken: HttpContext.RequestAborted);

	/// <summary>
	/// Games the URL asynchronous.
	/// </summary>
	/// <param name="service">The service.</param>
	/// <param name="source">The source.</param>
	/// <returns></returns>
	/// <remarks>
	/// <b>Example</b><br />
	///
	///     Post
	///
	///         {
	///             "apiUrl": " https://wc-api.orz16.com/",
	///             "deskey": "03CFE0179704BCDF",
	///             "mD5key": "337B01054C6FA208",
	///             "agentId": "60073",
	///             "brandCode": "GPI_PHP",
	///             "playerCode":"4uh3pdl0lcii",
	///             "ipAddress": "127.0.0.1",
	///             "externalGameId": "0",
	///             "lang": "en-us"
	///         }
	///
	///
	///     Post Baccarat
	///
	///         {
	///             "apiUrl": " https://wc-api.orz16.com/",
	///             "deskey": "03CFE0179704BCDF",
	///             "mD5key": "337B01054C6FA208",
	///             "agentId": "60073",
	///             "brandCode": "GPI_PHP",
	///             "playerCode":"4uh3pdl0lcii",
	///             "ipAddress": "127.0.0.1",
	///             "externalGameId": "910",
	///             "lang": "zh-cn"
	///         }
	/// </remarks>
	[HttpPost("gameurl")]
	public ValueTask<string> GameUrlAsync(
		[FromServices] IGetService<GameUrlQuery, string> service,
		GameUrlQuery source)
		=> service.GetAsync(
			query: source,
			cancellationToken: HttpContext.RequestAborted);

	/// <summary>
	/// Players the balance asynchronous.
	/// </summary>
	/// <param name="service">The service.</param>
	/// <param name="source">The source.</param>
	/// <returns></returns>
	/// <remarks>
	/// <b>Example</b><br />
	///
	///     Post
	///
	///         {
	///             "apiUrl": " https://wc-api.orz16.com/",
	///             "deskey": "03CFE0179704BCDF",
	///             "mD5key": "337B01054C6FA208",
	///             "agentId": "60073",
	///             "playerCode":"4uh3pdl0lcii"
	///         }
	/// </remarks>
	[HttpPost("player/balance", Name = "PlayerBalance")]
	public ValueTask<PlayerBalanceResult> PlayerBalanceAsync(
		[FromServices] IGetService<PlayerBalanceQuery, PlayerBalanceResult> service,
		PlayerBalanceQuery source)
		=> service.GetAsync(
			query: source,
			cancellationToken: HttpContext.RequestAborted);

	/// <summary>
	/// Players the online asynchronous.
	/// </summary>
	/// <param name="service">The service.</param>
	/// <param name="source">The source.</param>
	/// <returns></returns>
	/// <remarks>
	/// <b>Example</b><br />
	///
	///     Post
	///
	///         {
	///             "apiUrl": " https://wc-api.orz16.com/",
	///             "deskey": "03CFE0179704BCDF",
	///             "mD5key": "337B01054C6FA208",
	///             "agentId": "60073",
	///             "playerCode":"4uh3pdl0lcii"
	///         }
	/// </remarks>
	[HttpPost("player/online", Name = "PlayerOnline")]
	public ValueTask<bool> PlayerOnlineAsync(
		[FromServices] IGetService<PlayerOnlineQuery, bool> service,
		PlayerOnlineQuery source)
		=> service.GetAsync(
			query: source,
			cancellationToken: HttpContext.RequestAborted);

	/// <summary>
	/// Players the logout asynchronous.
	/// </summary>
	/// <param name="service">The service.</param>
	/// <param name="source">The source.</param>
	/// <returns></returns>
	/// <remarks>
	/// <b>Example</b><br />
	///
	///     Post
	///
	///         {
	///             "apiUrl": " https://wc-api.orz16.com/",
	///             "deskey": "03CFE0179704BCDF",
	///             "mD5key": "337B01054C6FA208",
	///             "agentId": "60073",
	///             "playerCode":"4uh3pdl0lcii"
	///         }
	/// </remarks>
	[HttpPost("player/logout", Name = "PlayerLogout")]
	public ValueTask PlayerLogoutAsync(
		[FromServices] ICommandService<PlayerLogoutCommand> service,
		PlayerLogoutCommand source)
		=> service.ExecuteAsync(
			command: source,
			cancellationToken: HttpContext.RequestAborted);

	/// <summary>
	/// Players the balance asynchronous.
	/// </summary>
	/// <param name="service">The service.</param>
	/// <param name="source">The source.</param>
	/// <returns></returns>
	/// <remarks>
	/// <b>Example</b><br />
	///
	///     Post
	///
	///         {
	///             "apiUrl": " https://wc-api.orz16.com/",
	///             "deskey": "03CFE0179704BCDF",
	///             "mD5key": "337B01054C6FA208",
	///             "agentId": "60073"
	///         }
	/// </remarks>
	[HttpPost("agent/balance", Name = "AgentBalance")]
	public ValueTask<AgentBalanceResult> AgentBalanceAsync(
		[FromServices] IGetService<AgentBalanceQuery, AgentBalanceResult> service,
		AgentBalanceQuery source)
		=> service.GetAsync(
			query: source,
			cancellationToken: HttpContext.RequestAborted);
}
