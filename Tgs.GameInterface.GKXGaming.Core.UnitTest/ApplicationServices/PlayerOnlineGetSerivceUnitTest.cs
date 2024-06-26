using NSubstitute;
using Tgs.GameInterface.GKXGaming.Core.ApplicationServices;
using Tgs.GameInterface.GKXGaming.Core.Models;

namespace Tgs.GameInterface.GKXGaming.Core.UnitTest.ApplicationServices;

public class PlayerOnlineGetSerivceUnitTest
{
	[Fact]
	public async Task Normal_ProcessAsync()
	{
		var query = new PlayerOnlineQuery(
			ApiUrl: new Uri("https://wc-api.orz16.com/"),
			Deskey: "03CFE0179704BCDF",
			MD5key: "337B01054C6FA208",
			AgentId: "60073",
			PlayerCode: "4uh3pdl0lcii");

		var fakeClient = Substitute.For<IGameApiClient>();

		var info = new BalanceInfo(
			TotalMoney: 100,
			FreeMoney: 98,
			Online: false);
		_ = fakeClient
			.BalanceAsync(
			Arg.Is(query.ApiUrl),
			Arg.Is(query.Deskey),
			Arg.Is(query.MD5key),
			Arg.Is(query.AgentId),
			Arg.Is(query.PlayerCode),
			Arg.Any<CancellationToken>())
			.Returns(info);

		var service = new PlayerOnlineGetSerivce(
			fakeClient);

		var actual = await service.GetAsync(
			query: query);

		Assert.False(actual);
	}
}
