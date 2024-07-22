namespace Vertr.Strategies.Domain;

/// <summary>
/// see https://github.com/dotnet/runtime/blob/main/src/libraries/Microsoft.Extensions.Hosting.Abstractions/src/BackgroundService.cs
/// </summary>
public abstract class BackgroundWorker : IDisposable
{
    private Task? _executeTask;
    private CancellationTokenSource? _stoppingCts;

    public virtual Task? ExecuteTask => _executeTask;

    protected abstract Task ExecuteAsync(CancellationToken stoppingToken);

    public virtual Task StartAsync(CancellationToken cancellationToken)
    {
        _stoppingCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

        _executeTask = ExecuteAsync(_stoppingCts.Token);

        if (_executeTask.IsCompleted)
        {
            return _executeTask;
        }

        return Task.CompletedTask;
    }

    public virtual async Task StopAsync(CancellationToken cancellationToken)
    {
        if (_executeTask == null)
        {
            return;
        }

        try
        {
            _stoppingCts!.Cancel();
        }
        finally
        {
            await _executeTask.WaitAsync(cancellationToken).ConfigureAwait(ConfigureAwaitOptions.SuppressThrowing);
        }
    }

    public virtual void Dispose()
    {
        _stoppingCts?.Cancel();
    }
}
