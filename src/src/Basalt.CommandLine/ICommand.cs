using System;
using System.CommandLine;
using System.Threading;
using System.Threading.Tasks;

namespace Basalt.CommandLine;

/// <summary>
/// Command context. Available during command lifecycle.
/// </summary>
public sealed class CommandContext
{
    /// <summary>
    /// Command line parse result.
    /// </summary>
    public ParseResult? ParseResult { get; set; }
    
    /// <summary>
    /// Cancellation token
    /// </summary>
    public CancellationToken CancellationToken { get; set; }

    /// <summary>
    /// Command options instance.
    /// </summary>
    public object? Options { get; set; }
}

/// <summary>
/// Command interface. All command classes should implement it.
/// </summary>
/// <typeparam name="TOptions">Command options type.</typeparam>
public interface ICommand<TOptions> : IAsyncDisposable
{
    /// <summary>
    /// Execute command.
    /// </summary>
    /// <returns>ValueTask instance</returns>
    ValueTask ExecuteAsync();
}