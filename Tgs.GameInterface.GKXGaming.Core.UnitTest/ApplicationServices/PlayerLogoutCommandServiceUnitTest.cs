using NSubstitute;
using Tgs.GameInterface.GKXGaming.Core.ApplicationServices;

namespace Tgs.GameInterface.GKXGaming.Core.UnitTest.ApplicationServices;

public class PlayerLogoutCommandServiceUnitTest
{
	[Fact]
	public async Task Normal_ProcessAsync()
	{
		var command = new PlayerLogoutCommand(
			ApiUrl: new Uri("https://wc-api.orz16.com/"),
			Deskey: "03CFE0179704BCDF",
			MD5key: "337B01054C6FA208",
			AgentId: "60073",
			PlayerCode: "4uh3pdl0lcii");

		var fakeClient = Substitute.For<IGameApiClient>();

		var service = new PlayerLogoutCommandService(
			fakeClient);

		await service.ExecuteAsync(
			command: command);

		_ = fakeClient
			.Received(1)
			.LogoutAsync(
			Arg.Is(command.ApiUrl),
			Arg.Is(command.Deskey),
			Arg.Is(command.MD5key),
			Arg.Is(command.AgentId),
			Arg.Is(command.PlayerCode),
			Arg.Any<CancellationToken>());
	}
}
