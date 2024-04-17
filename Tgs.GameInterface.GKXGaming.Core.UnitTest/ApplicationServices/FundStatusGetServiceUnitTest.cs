using NSubstitute;
using Tgs.GameInterface.GKXGaming.Core.ApplicationServices;

namespace Tgs.GameInterface.GKXGaming.Core.UnitTest.ApplicationServices;

public class FundStatusGetServiceUnitTest
{
	[Fact]
	public async Task Normal_ProcessAsync()
	{
		var query = new FundStatusQuery(
			ApiUrl: new Uri("https://wc-api.orz16.com/"),
			Deskey: "03CFE0179704BCDF",
			MD5key: "337B01054C6FA208",
			AgentId: "60073",
			OrderId: "60073202307260300148304uh3pdl0lcii");

		var fakeClient = Substitute.For<IGameApiClient>();

		var service = new FundStatusGetService(
			fakeClient);

		_ = await service.GetAsync(
			query: query);

		_ = fakeClient
			.Received(1)
			.GetOrderAsync(
			Arg.Is(query.ApiUrl),
			Arg.Is(query.Deskey),
			Arg.Is(query.MD5key),
			Arg.Is(query.AgentId),
			Arg.Is(query.OrderId),
			Arg.Any<CancellationToken>());
	}
}
