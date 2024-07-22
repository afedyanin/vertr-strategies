using System.Collections.Concurrent;
using Vertr.Strategies.Domain.Commands;

namespace Vertr.Strategies.Domain.Services;
public class CommandsQueue
{
    private readonly ConcurrentQueue<StartCommand> _startCommandsQueue;

    private readonly ConcurrentQueue<StopCommand> _stopCommandsQueue;



}
