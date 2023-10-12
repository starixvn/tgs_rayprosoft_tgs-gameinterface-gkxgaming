using NSubstitute;
using Tgs.GameInterface.GKXGaming.Core.ApplicationServices;
using Tgs.GameInterface.GKXGaming.Core.Models;

namespace Tgs.GameInterface.GKXGaming.Core.UnitTest.ApplicationServices;

public class FundOutGetServiceUnitTest
{
    [Fact]
    public async Task Normal_ProcessAsync()
    {
        var query = new FundOutQuery(
            ApiUrl: new Uri("https://wc-api.orz16.com/"),
            Deskey: "03CFE0179704BCDF",
            MD5key: "337B01054C6FA208",
            AgentId: "60073",
            PlayerCode: "4uh3pdl0lcii",
            OrderId: "6007320202310120336009404uh3pdl0lcii",
            Amount: 1.0m);

        var fakeClient = Substitute.For<IGameApiClient>();

        _ = fakeClient
            .DepositAsync(
            Arg.Is(query.ApiUrl),
            Arg.Is(query.Deskey),
            Arg.Is(query.MD5key),
            Arg.Is(query.AgentId),
            Arg.Is(query.PlayerCode),
            Arg.Is(query.OrderId),
            Arg.Is(query.Amount),
            Arg.Any<CancellationToken>())
            .Returns(new ValueTask<DepositResp>(
                new DepositResp(Resp: "{\"m\":\"/channelHandle\",\"s\":102,\"d\":{\"code\":0,\"money\":\"1.00\"}}")));

        var service = new FundOutGetService(
            fakeClient);

        var actual = await service.GetAsync(query: query);

        Assert.Equal("{\"m\":\"/channelHandle\",\"s\":102,\"d\":{\"code\":0,\"money\":\"1.00\"}}", actual.Resp);
    }
}
