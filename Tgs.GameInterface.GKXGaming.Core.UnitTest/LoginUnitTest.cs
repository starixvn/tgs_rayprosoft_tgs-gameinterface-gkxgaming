using System.Net;
using System.Net.Mime;
using System.Text;
using System.Text.Json.Nodes;
using System.Web;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using NSubstitute;
using RichardSzalay.MockHttp;

namespace Tgs.GameInterface.GKXGaming.Core.UnitTest;

public class LoginUnitTest
{
	[Fact]
	public async Task Normal_Process()
	{
		var policySettingsOptions = Options.Create(new PolicySettingsOptions
		{
			DepositRetryCount = 1,
			DepositRetryWaitSec = 1,
			GameRecordRetryCount = 1,
			GameRecordRetryWaitSec = 1
		});

		var apiUrl = new Uri("https://wc-api.orz16.com/");
		var deskey = "03CFE0179704BCDF";
		var md5key = "337B01054C6FA208";
		var agentId = "60073";
		var account = "4uh3pdl0lcii";
		var ipAddress = "127.0.0.1";
		var lineCode = "GPI_PHP";

		var fakeCryptography = Substitute.For<IHashCryptography>();
		var fakeSystemClock = Substitute.For<ISystemClock>();

		var currentTime = DateTimeOffset.FromUnixTimeMilliseconds(1697077837833);
		_ = fakeSystemClock.CurrentTime.Returns(currentTime);

		var data = "s=0&account=4uh3pdl0lcii&money=0&orderid=60073202310120230378334uh3pdl0lcii&ip=127.0.0.1&lineCode=GPI_PHP";
		var param = "oCKRHPQ9LbMrbqxJuK4bxyOm7cc2MfVKCeUI8RbrEjv7d96Xzf0qRYpwY/vtEHrySj0RSCU7xkI7Q1zC12AFXwq231Henc7KgnXSZVzXdjVEr2EU5kuvRoQGLJ95REr0+2Fa41CE66wfFZQsriBNGg==";
		_ = fakeCryptography.GetAesEncryptAsync(
			data: Arg.Is(data),
			secretKey: Arg.Is(deskey),
			cancellationToken: Arg.Any<CancellationToken>())
			.Returns(param);

		var dataMD5 = $"{agentId}{currentTime.ToUnixTimeMilliseconds()}{md5key}";
		var key = "2f72cd7b2bc87c60f2b9dd6e45268097";
		_ = fakeCryptography.GetHash(
			data: Arg.Is(dataMD5))
			.Returns(key);

		var uriBuilder = new UriBuilder(new Uri(apiUrl, "/channelHandle"));
		var query = HttpUtility.ParseQueryString(uriBuilder.Query);
		query["agent"] = agentId;
		query["timestamp"] = currentTime.ToUnixTimeMilliseconds().ToString();
		query["param"] = param;
		query["key"] = key;
		uriBuilder.Query = query.ToString();

		var response = new JsonObject
		{
			["m"] = "/channelHandle",
			["s"] = 100,
			["d"] = new JsonObject
			{
				["code"] = 0,
				["url"] = "https://wc-h5.orz16.com/",
			}
		};

		var handler = new MockHttpMessageHandler();
		_ = handler
			.Expect(HttpMethod.Get, uriBuilder.ToString())
			.Respond(HttpStatusCode.OK, new StringContent(response.ToJsonString(), Encoding.UTF8, MediaTypeNames.Application.Json));

		var fakeHttpClient = handler.ToHttpClient();
		var fakeLog = NullLogger<GameApiClient>.Instance;

		var client = new GameApiClient(
			fakeLog,
			policySettingsOptions,
			fakeCryptography,
			fakeSystemClock,
			fakeHttpClient);

		var actual = await client.LoginAsync(
			apiUrl: apiUrl,
			deskey: deskey,
			md5key: md5key,
			agentId: agentId,
			account: account,
			ipAddress: ipAddress,
			lineCode: lineCode);

		Assert.NotNull(actual);
		Assert.Equal("https://wc-h5.orz16.com/", actual);
	}
}
