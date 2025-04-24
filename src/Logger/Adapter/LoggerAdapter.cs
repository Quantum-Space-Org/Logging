using System;
using Serilog;

namespace Quantum.Logging.Adapter;

public class LoggerAdapter : ILoggerAdapter
{
    private readonly Serilog.ILogger _logger = Log.Logger;
    

    public void Write(LogEventLevel level, string messageTemplate)
    {
        var logLevel = LogLevel(level);

        if(_logger.IsEnabled(logLevel) is true)
            _logger.Write(logLevel, messageTemplate);
    }

    

    public void Write<T>(LogEventLevel level, string messageTemplate, T propertyValue)
    {
        var logLevel = LogLevel(level);

        if (_logger.IsEnabled(logLevel) is true)
            _logger.Write(logLevel, messageTemplate, propertyValue);
    }

    public void Write<T0, T1>(LogEventLevel level, string messageTemplate, T0 propertyValue0, T1 propertyValue1)
    {

        var logLevel = LogLevel(level);

        if (_logger.IsEnabled(logLevel) is true)
            _logger.Write(logLevel, messageTemplate, propertyValue0, propertyValue1);
    }

    public void Write<T0, T1, T2>(LogEventLevel level, string messageTemplate, T0 propertyValue0, T1 propertyValue1,
        T2 propertyValue2)
    {
        var logLevel = LogLevel(level);

        if (_logger.IsEnabled(logLevel) is true)
            _logger.Write(logLevel, messageTemplate, propertyValue0, propertyValue1, propertyValue2);
    }

    public void Write(LogEventLevel level, Exception? exception, string messageTemplate)
    {
        var logLevel = LogLevel(level);

        if (_logger.IsEnabled(logLevel) is true)
            _logger.Write(logLevel, exception , messageTemplate);
    }

    public void Write<T>(LogEventLevel level, Exception? exception, string messageTemplate, T propertyValue)
    {
        var logLevel = LogLevel(level);

        if (_logger.IsEnabled(logLevel) is true)
            _logger.Write(logLevel, exception, messageTemplate, propertyValue);
    }

    public void Write<T0, T1>(LogEventLevel level, Exception? exception, string messageTemplate, T0 propertyValue0,
        T1 propertyValue1)
    {
        var logLevel = LogLevel(level);

        if (_logger.IsEnabled(logLevel) is true)
            _logger.Write(logLevel, exception,messageTemplate, propertyValue0, propertyValue1);
    }

    public void Write<T0, T1, T2>(LogEventLevel level, Exception? exception, string messageTemplate, T0 propertyValue0,
        T1 propertyValue1, T2 propertyValue2)
    {
        var logLevel = LogLevel(level);

        if (_logger.IsEnabled(logLevel) is true)
            _logger.Write(logLevel, exception, messageTemplate, propertyValue0, propertyValue1, propertyValue2);
    }
    

    private static Serilog.Events.LogEventLevel LogLevel(LogEventLevel level)
    {
        Serilog.Events.LogEventLevel logLevel;
        switch (level)
        {
            case LogEventLevel.Verbose:
                logLevel = Serilog.Events.LogEventLevel.Verbose;
                break;
            case LogEventLevel.Debug:
                logLevel = Serilog.Events.LogEventLevel.Debug;
                break;
            case LogEventLevel.Information:
                logLevel = Serilog.Events.LogEventLevel.Information;
                break;
            case LogEventLevel.Warning:
                logLevel = Serilog.Events.LogEventLevel.Warning;
                break;
            case LogEventLevel.Error:
                logLevel = Serilog.Events.LogEventLevel.Error;
                break;
            case LogEventLevel.Fatal:
                logLevel = Serilog.Events.LogEventLevel.Fatal;
                break;
            default:
                logLevel = Serilog.Events.LogEventLevel.Information;
                break;
        }

        return logLevel;
    }
}