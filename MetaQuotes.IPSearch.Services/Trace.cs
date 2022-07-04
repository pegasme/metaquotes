using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace MetaQuotes.IPSearch.Services;

public class Trace: IDisposable
{
    private readonly ILogger _logger;
    private readonly Stopwatch _stopWatch;
    public Trace(ILogger logger) { 
        _logger = logger;
        _stopWatch = new Stopwatch();
        _stopWatch.Start();
    }

    public void Dispose()
    {
        _stopWatch.Stop();
        _logger.LogInformation(_stopWatch.Elapsed.ToString());
    }
}
