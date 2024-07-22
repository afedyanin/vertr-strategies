namespace Vertr.Strategies.Domain.Abstractions;
public interface ITradeSignalsQueue
{
    bool TryGet(out TradeSignal? tradingSignal);

    void Put(TradeSignal signal);
}
