
namespace Vertr.Strategies.Domain.Tests;

[TestFixture(Category = "Unit", Explicit = false)]
public class Tests
{
    [Test]
    public async Task CanStartWorker()
    {
        var worker = new WorkerStub();
        var cts = new CancellationTokenSource();

        await worker.StartAsync(cts.Token);

        await Task.Delay(9_000);

        await worker.StopAsync(cts.Token);

        Assert.Pass();
    }

    private sealed class WorkerStub : BackgroundWorker
    {
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine($"Execution started at: {DateTimeOffset.Now}");
            return base.StartAsync(cancellationToken);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    Console.WriteLine($"Worker running at: {DateTimeOffset.Now}");
                    await Task.Delay(1_000, stoppingToken);
                }
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine($"Execution cancelled at: {DateTimeOffset.Now}");
            }
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine($"Execution stopping at: {DateTimeOffset.Now}");
            return base.StopAsync(cancellationToken);
        }
    }
}
