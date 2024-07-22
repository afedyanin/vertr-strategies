
using System.Collections.Concurrent;

namespace Vertr.Strategies.Domain.Services;

public class SignalsQueue
{
    private readonly ConcurrentQueue<TradeSignal> _tradingSignalsQueue;

    public SignalsQueue()
    {
        _tradingSignalsQueue = new ConcurrentQueue<TradeSignal>();
    }

    public bool TryDequeue(out TradeSignal? tradingSignal)
    {
        var res = _tradingSignalsQueue.TryDequeue(out tradingSignal);
        return res;
    }

    public void Enqueue(TradeSignal signal)
    {
        _tradingSignalsQueue.Enqueue(signal);
    }
}
