using System.Diagnostics;

namespace Tgs.GameInterface.GKXGaming.Client;

public class DiagnosticsInterceptorOptions
{
	public ActivitySource InterceptorActivitySource { get; set; } =
		new ActivitySource($"Tgs.GameInterface.GKXGaming.Client.DiagnosticsInterceptor");
}
