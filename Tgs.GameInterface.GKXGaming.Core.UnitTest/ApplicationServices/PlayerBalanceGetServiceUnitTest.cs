using NSubstitute;
using Tgs.GameInterface.GKXGaming.Core.ApplicationServices;
using Tgs.GameInterface.GKXGaming.Core.Models;

namespace Tgs.GameInterface.GKXGaming.Core.UnitTest.ApplicationServices;

public class PlayerBalanceGetServiceUnitTest
{
	[Fact]
	public async Task Normal_ProcessAsync()
	{
		var query = new PlayerBalanceQuery(
			ApiUrl: new Uri("https://wc-api.orz16.com/"),
			Deskey: "03CFE0179704BCDF",
			MD5key: "337B01054C6FA208",
			AgentId: "60073",
			PlayerCode: "4uh3pdl0lcii");

		var fakeClient = Substitute.For<IGameApiClient>();

		var info = new BalanceInfo(
			TotalMoney: 100,
			FreeMoney: 98);
		_ = fakeClient
			.BalanceAsync(
			Arg.Is(query.ApiUrl),
			Arg.Is(query.Deskey),
			Arg.Is(query.MD5key),
			Arg.Is(query.AgentId),
			Arg.Is(query.PlayerCode),
			Arg.Any<CancellationToken>())
			.Returns(info);

		var service = new PlayerBalanceGetService(
			fakeClient);

		var actual = await service.GetAsync(
			query: query);

		Assert.NotNull(actual);
		Assert.Equal(100, actual.Balance);
		Assert.Equal(98, actual.FreeBalance);
		Assert.Equal(2, actual.OutstandingBalance);
	}
}
