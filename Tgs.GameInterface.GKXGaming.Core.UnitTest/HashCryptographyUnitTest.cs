namespace Tgs.GameInterface.GKXGaming.Core.UnitTest;

public class HashCryptographyUnitTest
{
	[Fact]
	public void Hash()
	{
		var hashCryptography = new HashCryptography();
		var agent = 60073;
		var timestamp = 1690340035435;
		var md5Key = "337B01054C6FA208";
		var data = $"{agent}{timestamp}{md5Key}";
		var actual = hashCryptography.GetHash(data: data);

		Assert.NotNull(actual);
		Assert.Equal("8fb4c566536d3920b27a45282cf6ccf8", actual);
	}

	[Fact]
	public async Task AesEncrypt_Balance()
	{
		var hashCryptography = new HashCryptography();
		var secretKey = "03CFE0179704BCDF";
		var data = $"s=7&account=4uh3pdl0lcii";
		var actual = await hashCryptography.GetAesEncryptAsync(
			data: data,
			secretKey: secretKey);

		Assert.NotNull(actual);
		Assert.Equal("mZpkgwsrl5IcHbFEQ7lNCsHYa5KjJLDQ2Ci8bKmi1Mk=", actual);
	}

	[Fact]
	public async Task AesEncrypt_Deposit()
	{
		var hashCryptography = new HashCryptography();
		var secretKey = "03CFE0179704BCDF";
		var data = $"s=2&account=4uh3pdl0lcii&money=1.0&orderid=60073202307260300148304uh3pdl0lcii";
		var actual = await hashCryptography.GetAesEncryptAsync(
			data: data,
			secretKey: secretKey);

		Assert.NotNull(actual);
		Assert.Equal("TbtFF2DiUgMte40WAVvMql/mpqqfcg/kpcgn445P7zHdSVONSwI7nDu9XNXV0fpqqDt/WmK1/c0B9hfJLqob/MUjQfVQ84ha7DM+ASBOLfs=", actual);
	}

	[Fact]
	public async Task AesEncrypt_Withdrawal()
	{
		var hashCryptography = new HashCryptography();
		var secretKey = "03CFE0179704BCDF";
		var data = $"s=3&account=4uh3pdl0lcii&orderid=60073202307171354537634uh3pdl0lcii&money=1";
		var actual = await hashCryptography.GetAesEncryptAsync(
			data: data,
			secretKey: secretKey);

		Assert.NotNull(actual);
		Assert.Equal("Q5ujk4MH14v/bhF0wRxZ9MThfH0ylsjYj5MNaE0s6k0Xr4GLEt+PD3AdhvazMB+tsfkL1OSyvFILnmQijMiwk7fiYAcyeOkt2G123vwbDCo=", actual);
	}

	[Fact]
	public async Task AesEncrypt_Login()
	{
		var hashCryptography = new HashCryptography();
		var secretKey = "03CFE0179704BCDF";
		var data = $"s=0&account=4uh3pdl0lcii&money=0&orderid=60073202307260309201174uh3pdl0lcii&ip=127.0.0.1&lineCode=GPI_PHP";
		var actual = await hashCryptography.GetAesEncryptAsync(
			data: data,
			secretKey: secretKey);

		Assert.NotNull(actual);
		Assert.Equal("oCKRHPQ9LbMrbqxJuK4bxyOm7cc2MfVKCeUI8RbrEjv7d96Xzf0qRYpwY/vtEHrywUfsg4H3IAU0jENUYhbD6gq231Henc7KgnXSZVzXdjVEr2EU5kuvRoQGLJ95REr0+2Fa41CE66wfFZQsriBNGg==", actual);
	}

	[Fact]
	public async Task AesEncrypt_GameRecord()
	{
		var hashCryptography = new HashCryptography();
		var secretKey = "03CFE0179704BCDF";
		var data = $"s=6&startTime=1689573304660&endTime=1689573604660";
		var actual = await hashCryptography.GetAesEncryptAsync(
			data: data,
			secretKey: secretKey);

		Assert.NotNull(actual);
		Assert.Equal("QZM3KRZ9QYFVqQ5i2mjV/9bBtHWv/QBVGTYl74yuq8nvVrHQahvBkiReyFChs933wB7kWcSmG1ZhwR/HRI1htA==", actual);
	}
}
