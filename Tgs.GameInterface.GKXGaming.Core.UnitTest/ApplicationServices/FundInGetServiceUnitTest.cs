using NSubstitute;
using Tgs.GameInterface.GKXGaming.Core.ApplicationServices;
using Tgs.GameInterface.GKXGaming.Core.Models;

namespace Tgs.GameInterface.GKXGaming.Core.UnitTest.ApplicationServices;

public class FundInGetServiceUnitTest
{
	[Fact]
	public async Task Normal_ProcessAsync()
	{
		var query = new FundInQuery(
			ApiUrl: new Uri("https://wc-api.orz16.com/"),
			Deskey: "03CFE0179704BCDF",
			MD5key: "337B01054C6FA208",
			AgentId: "60073",
			PlayerCode: "4uh3pdl0lcii",
			OrderId: "60073202310120338068944uh3pdl0lcii",
			Amount: 1.0m);

		var fakeClient = Substitute.For<IGameApiClient>();

		_ = fakeClient
			.WithdrawAsync(
			Arg.Is(query.ApiUrl),
			Arg.Is(query.Deskey),
			Arg.Is(query.MD5key),
			Arg.Is(query.AgentId),
			Arg.Is(query.PlayerCode),
			Arg.Is(query.OrderId),
			Arg.Is(query.Amount),
			Arg.Any<CancellationToken>())
			.Returns(new ValueTask<WithdrawResp>(
				new WithdrawResp(Resp: "{\"m\":\"/channelHandle\",\"s\":103,\"d\":{\"code\":0,\"money\":\"0.00\"}}")));

		var service = new FundInGetService(
			fakeClient);

		var actual = await service.GetAsync(query: query);

		Assert.Equal("{\"m\":\"/channelHandle\",\"s\":103,\"d\":{\"code\":0,\"money\":\"0.00\"}}", actual.Resp);
	}
}
