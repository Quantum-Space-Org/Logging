using System;
using Serilog;

namespace Quantum.Logging.Adapter;

public class QuantumLogger
{
    private static readonly Serilog.ILogger Logger = Log.Logger;

    public static void Information(string messageTemplate)
    {
        Logger.Information(messageTemplate);
    }

    public static void Fatal(Exception exception, string message)
    {
        Logger.Fatal(exception, message);
    }

    public static void Fatal<T>(Exception exception, string message, T param)
    {
        Logger.Fatal(exception, message, param);
    }

    public static void Debug(string messageTemplate)
    {
        Logger.Debug(messageTemplate);
    }
}