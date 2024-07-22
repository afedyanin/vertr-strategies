
using System.Collections.Concurrent;
using Vertr.Strategies.Domain.Abstractions;

namespace Vertr.Strategies.Domain.Services;

public class TradeSignalsInMemoryQueue : ITradeSignalsQueue
{
    private readonly ConcurrentQueue<TradeSignal> _tradeSignalsQueue;

    public TradeSignalsInMemoryQueue()
    {
        _tradeSignalsQueue = new ConcurrentQueue<TradeSignal>();
    }

    public bool TryGet(out TradeSignal? tradingSignal)
    {
        var res = _tradeSignalsQueue.TryDequeue(out tradingSignal);
        return res;
    }

    public void Put(TradeSignal signal)
    {
        _tradeSignalsQueue.Enqueue(signal);
    }
}
