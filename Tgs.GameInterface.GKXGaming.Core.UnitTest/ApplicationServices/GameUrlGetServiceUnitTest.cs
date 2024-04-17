using NSubstitute;
using Tgs.GameInterface.GKXGaming.Core.ApplicationServices;

namespace Tgs.GameInterface.GKXGaming.Core.UnitTest.ApplicationServices;

public class GameUrlGetServiceUnitTest
{
	[Fact]
	public async Task Normal_ProcessAsync()
	{
		var query = new GameUrlQuery(
			ApiUrl: new Uri("https://wc-api.orz16.com/"),
			Deskey: "03CFE0179704BCDF",
			MD5key: "337B01054C6FA208",
			AgentId: "60073",
			BrandCode: "GPI",
			PlayerCode: "4uh3pdl0lcii",
			IpAddress: "127.0.0.1",
			ExternalGameId: "0",
			Lang: "en-us");

		var fakeClient = Substitute.For<IGameApiClient>();

		_ = fakeClient
			.LoginAsync(
			Arg.Is(query.ApiUrl),
			Arg.Is(query.Deskey),
			Arg.Is(query.MD5key),
			Arg.Is(query.AgentId),
			Arg.Is(query.PlayerCode),
			Arg.Is(query.IpAddress),
			Arg.Is(query.BrandCode),
			Arg.Any<CancellationToken>())
			.Returns("https://wc-h5.orz16.com?account=60073_4uh3pdl0lcii&token=eyJkYXRhIjoiNjAwNzNfNHVoM3BkbDBsY2lpIiwiY3JlYXRlZCI6MTY5NzA3Nzg2MywiZXhwIjozMDAsImFjY0xldmVsIjoiTFY1In0=.NYUG96iiOAfKinF/cZ7H03nIKt1+MI/TGfquo6BilPM=&lang=zh-cn&defaultSkin=[4]&route=wss://wc-wss.orz16.com&loudou=https://wc-loud.orz16.com/statisticsHandle&moneyType=1");

		var service = new GameUrlGetService(
			fakeClient);

		var actual = await service.GetAsync(query: query);

		Assert.NotNull(actual);
		Assert.Contains("gameId=0", actual);
		Assert.Contains("lang=en-us", actual);
		Assert.DoesNotContain("lang=zh-cn", actual);
	}
}
