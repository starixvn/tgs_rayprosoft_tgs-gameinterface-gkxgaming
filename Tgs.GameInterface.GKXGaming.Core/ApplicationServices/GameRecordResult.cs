namespace Tgs.GameInterface.GKXGaming.Core.ApplicationServices;

public record GameRecordResult(
    string ExternalRoundId,
    string ExternalWagerId,
    string ExternalGameId,
    string PlayerCode,
    DateTimeOffset ExternalCreatedOn,
    DateTimeOffset ExternalClosedOn,
    decimal Bet,
    decimal ValidBet,
    decimal Settle,
    decimal Commission,
    decimal WinLoss,
    string AdditionalData);
