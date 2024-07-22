
namespace Vertr.Strategies.Domain.Tests;

[TestFixture(Category = "Unit", Explicit = false)]
public class Tests
{
    [Test]
    public async Task CanStartWorker()
    {
        var worker = new WorkerStub();
        await worker.StartAsync();
        await Task.Delay(9_000);
        await worker.StopAsync();

        Assert.Pass();
    }

    [Test]
    public async Task CanStartTwice()
    {
        var worker = new WorkerStub();
        await worker.StartAsync();
        await Task.Delay(2_000);
        await worker.StartAsync();
        await Task.Delay(2_000);
        await worker.StopAsync();

        Assert.Pass();
    }

    [Test]
    public async Task CanStopTwice()
    {
        var worker = new WorkerStub();
        await worker.StartAsync();
        await Task.Delay(2_000);
        await worker.StopAsync();
        await Task.Delay(2_000);
        await worker.StopAsync();

        Assert.Pass();
    }



    private sealed class WorkerStub : BackgroundWorker
    {
        public override Task StartAsync(CancellationToken cancellationToken = default)
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

        public override Task StopAsync(CancellationToken cancellationToken = default)
        {
            Console.WriteLine($"Execution stopping at: {DateTimeOffset.Now}");
            return base.StopAsync(cancellationToken);
        }
    }
}
