using Microsoft.Extensions.Logging;
using Serilog;

namespace Quantum.Logging.Extensions;

public static class LoggerFactoryExtensions
{

    public static void AddQuantumLogger(this ILoggerFactory loggerFactory)
    {
        loggerFactory.AddSerilog(Log.Logger, true);
    }
}