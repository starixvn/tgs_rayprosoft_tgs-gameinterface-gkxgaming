using System.Diagnostics;

namespace Tgs.GameInterface.GKXGaming;

public class DiagnosticsInterceptorOptions
{
	public ActivitySource InterceptorActivitySource { get; set; } =
		new ActivitySource($"Tgs.GameInterface.GKXGaming.DiagnosticsInterceptor");
}
