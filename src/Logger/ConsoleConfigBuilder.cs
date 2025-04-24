using System;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

namespace Quantum.Logging;

/// <summary>
/// Writes log events to <see cref="T:System.Console" />.
/// </summary>
/// <param name="sinkConfiguration">Logger sink configuration.</param>
/// <param name="restrictedToMinimumLevel">The minimum level for
/// events passed through the sink. Ignored when <paramref name="levelSwitch" /> is specified.</param>
/// <param name="outputTemplate">A message template describing the format used to write to the sink.
/// The default is <code>"[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}"</code>.</param>
/// <param name="syncRoot">An object that will be used to `lock` (sync) access to the console output. If you specify this, you
/// will have the ability to lock on this object, and guarantee that the console sink will not be about to output anything while
/// the lock is held.</param>
/// <param name="formatProvider">Supplies culture-specific formatting information, or null.</param>
/// <param name="levelSwitch">A switch allowing the pass-through minimum level
/// to be changed at runtime.</param>
/// <param name="standardErrorFromLevel">Specifies the level at which events will be written to standard error.</param>
/// <param name="theme">The theme to apply to the styled output. If not specified,
/// uses <see cref="P:Serilog.Sinks.SystemConsole.Themes.SystemConsoleTheme.Literate" />.</param>
/// <param name="applyThemeToRedirectedOutput">Applies the selected or default theme even when output redirection is detected.</param>
/// <returns>Configuration object allowing method chaining.</returns>
/// <exception cref="T:System.ArgumentNullException">When <paramref name="sinkConfiguration" /> is <code>null</code></exception>
/// <exception cref="T:System.ArgumentNullException">When <paramref name="outputTemplate" /> is <code>null</code></exception>
/// 
public class ConsoleConfigBuilder
{
    public static ConsoleConfigBuilder IWantToConfigConsole => new();

    private LogEventLevel _restrictedToMinimumLevel = LogEventLevel.Verbose;
    private string _outputTemplate;

    private IFormatProvider _formatProvider = null;

    private LoggingLevelSwitch? _levelSwitch = null;

    private LogEventLevel? _standardErrorFromLevel = null;

    private ConsoleTheme? _theme = null;

    private bool _applyThemeToRedirectedOutput = false;
    private object? _syncRoot = null;


    public ConsoleConfigBuilder WithLogEventLevel(LogEventLevel level)
    {
        _restrictedToMinimumLevel = level;
        return this;
    }

    public ConsoleConfigBuilder WithOutputTemplate(string outputTemplate)
    {
        _outputTemplate = outputTemplate;
        return this;
    }
    public ConsoleConfigBuilder WithFormatProvider(IFormatProvider formatProvider)
    {
        _formatProvider = formatProvider;
        return this;
    }
    public ConsoleConfigBuilder WithLoggingLevelSwitch(LoggingLevelSwitch levelSwitch)
    {
        _levelSwitch = levelSwitch;
        return this;
    }

    public ConsoleConfigBuilder WithStandardErrorFromLevel(LogEventLevel standardErrorFromLevel)
    {
        _standardErrorFromLevel = standardErrorFromLevel;
        return this;
    }

    public ConsoleConfigBuilder WithConsoleTheme(ConsoleTheme theme)
    {
        _theme = theme;
        return this;
    }

    public ConsoleConfigBuilder WithApplyThemeToRedirectedOutput(bool applyThemeToRedirectedOutput)
    {
        _applyThemeToRedirectedOutput = applyThemeToRedirectedOutput;
        return this;
    }
    public ConsoleConfigBuilder WithSyncRoot(object syncRoot)
    {
        _syncRoot = syncRoot;
        return this;
    }


    internal void Build(LoggerConfiguration loggerConfiguration, string outputTemplate)
    {
        loggerConfiguration.WriteTo.Console(_restrictedToMinimumLevel
            , string.IsNullOrWhiteSpace(_outputTemplate) ? outputTemplate : _outputTemplate, _formatProvider, _levelSwitch, _standardErrorFromLevel, _theme,
            _applyThemeToRedirectedOutput, _syncRoot);
    }
}