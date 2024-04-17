namespace Tgs.GameInterface.GKXGaming.ViewModels;

public record PlayerBalanceResultViewModel(
	decimal Balance,
	decimal FreeBalance,
	decimal OutstandingBalance);
