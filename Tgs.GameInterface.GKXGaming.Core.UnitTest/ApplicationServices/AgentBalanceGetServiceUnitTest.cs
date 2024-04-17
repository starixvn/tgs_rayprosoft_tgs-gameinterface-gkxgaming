using NSubstitute;
using Tgs.GameInterface.GKXGaming.Core.ApplicationServices;

namespace Tgs.GameInterface.GKXGaming.Core.UnitTest.ApplicationServices;

public class AgentBalanceGetServiceUnitTest
{
	[Fact]
	public async Task Normal_ProcessAsync()
	{
		var query = new AgentBalanceQuery(
			ApiUrl: new Uri("https://wc-api.orz16.com/"),
			Deskey: "03CFE0179704BCDF",
			MD5key: "337B01054C6FA208",
			AgentId: "60073");

		var fakeClient = Substitute.For<IGameApiClient>();

		var credit = 10000000.00m;
		_ = fakeClient
			.AgentBalanceAsync(
			Arg.Is(query.ApiUrl),
			Arg.Is(query.Deskey),
			Arg.Is(query.MD5key),
			Arg.Is(query.AgentId),
			Arg.Any<CancellationToken>())
			.Returns(credit);

		var service = new AgentBalanceGetService(
			fakeClient);

		var actual = await service.GetAsync(
			query: query);

		Assert.NotNull(actual);
		Assert.Equal(10000000.00m, actual.Credit);
	}
}
