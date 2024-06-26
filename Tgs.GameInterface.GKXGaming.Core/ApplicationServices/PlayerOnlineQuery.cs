namespace Tgs.GameInterface.GKXGaming.Core.ApplicationServices;

public record PlayerOnlineQuery(
	Uri ApiUrl,
	string Deskey,
	string MD5key,
	string AgentId,
	string PlayerCode);
