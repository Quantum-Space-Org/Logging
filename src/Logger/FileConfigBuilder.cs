using System;
using System.Text;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting;
using Serilog.Sinks.File;

namespace Quantum.Logging;

/// <summary>Write log events to the specified file.</summary>
/// <param name="sinkConfiguration">Logger sink configuration.</param>
/// <param name="path">Path to the file.</param>
/// <param name="restrictedToMinimumLevel">The minimum level for
/// events passed through the sink. Ignored when <paramref name="levelSwitch" /> is specified.</param>
/// <param name="levelSwitch">A switch allowing the pass-through minimum level
/// to be changed at runtime.</param>
/// <param name="formatProvider">Supplies culture-specific formatting information, or null.</param>
/// <param name="outputTemplate">A message template describing the format used to write to the sink.
/// the default is "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}".</param>
/// <param name="fileSizeLimitBytes">The approximate maximum size, in bytes, to which a log file will be allowed to grow.
/// For unrestricted growth, pass null. The default is 1 GB. To avoid writing partial events, the last event within the limit
/// will be written in full even if it exceeds the limit.</param>
/// <param name="buffered">Indicates if flushing to the output file can be buffered or not. The default
/// is false.</param>
/// <param name="shared">Allow the log file to be shared by multiple processes. The default is false.</param>
/// <param name="flushToDiskInterval">If provided, a full disk flush will be performed periodically at the specified interval.</param>
/// <param name="rollingInterval">The interval at which logging will roll over to a new file.</param>
/// <param name="rollOnFileSizeLimit">If <code>true</code>, a new file will be created when the file size limit is reached. Filenames
/// will have a number appended in the format <code>_NNN</code>, with the first filename given no number.</param>
/// <param name="retainedFileCountLimit">The maximum number of log files that will be retained,
/// including the current log file. For unlimited retention, pass null. The default is 31.</param>
/// <param name="encoding">Character encoding used to write the text file. The default is UTF-8 without BOM.</param>
/// <param name="hooks">Optionally enables hooking into log file lifecycle events.</param>
/// <param name="retainedFileTimeLimit">The maximum time after the end of an interval that a rolling log file will be retained.
/// Must be greater than or equal to <see cref="F:System.TimeSpan.Zero" />.
/// Ignored if <paramref see="rollingInterval" /> is <see cref="F:Serilog.RollingInterval.Infinite" />.
/// The default is to retain files indefinitely.</param>
/// <returns>Configuration object allowing method chaining.</returns>
/// <exception cref="T:System.ArgumentNullException">When <paramref name="sinkConfiguration" /> is <code>null</code></exception>
/// <exception cref="T:System.ArgumentNullException">When <paramref name="path" /> is <code>null</code></exception>
/// <exception cref="T:System.ArgumentNullException">When <paramref name="outputTemplate" /> is <code>null</code></exception>
/// <exception cref="T:System.IO.IOException"></exception>
/// <exception cref="T:System.InvalidOperationException"></exception>
/// <exception cref="T:System.NotSupportedException"></exception>
/// <exception cref="T:System.IO.PathTooLongException">When <paramref name="path" /> is too long</exception>
/// <exception cref="T:System.UnauthorizedAccessException">The caller does not have the required permission to access the <paramref name="path" /></exception>
/// <exception cref="T:System.ArgumentException">Invalid <paramref name="path" /></exception>

public class FileConfigBuilder
{
    public static FileConfigBuilder IWantToConfigFile => new();
    private string _path;
    private LogEventLevel _restrictedToMinimumLevel = LogEventLevel.Verbose;

    private string _outputTemplate ;

    private IFormatProvider? _formatProvider = null;
    private ITextFormatter? _textFormatter = null;
    private long? _fileSizeLimitBytes = 1073741824;
    private LoggingLevelSwitch? _levelSwitch = null;
    private bool _buffered = false;
    private bool _shared = false;
    private TimeSpan? _flushToDiskInterval = null;
    private RollingInterval _rollingInterval = RollingInterval.Infinite;
    private bool _rollOnFileSizeLimit = false;
    private int? _retainedFileCountLimit = 31;
    private Encoding? _encoding ;
    private FileLifecycleHooks? _hooks = null;
    private TimeSpan? _retainedFileTimeLimit = null;

    public FileConfigBuilder WithPath(string path)
    {
        _path = path;
        return this;
    }

    public FileConfigBuilder WithLogLevel(LogEventLevel level)
    {
        _restrictedToMinimumLevel = level;
        return this;
    }

    public FileConfigBuilder WithOutputTemplate(string template)
    {
        _outputTemplate = template;
        return this;
    }
    public FileConfigBuilder WithFormatProvider(IFormatProvider formatProvider)
    {
        _formatProvider = formatProvider;
        return this;
    }

    public FileConfigBuilder WithFormatProvider(ITextFormatter textFormatter)
    {
        _textFormatter = textFormatter;
        return this;
    }
    public FileConfigBuilder WithFileSizeLimitBytes(long size)
    {
        _fileSizeLimitBytes = size;
        return this;
    }
    public FileConfigBuilder WithLoggingLevelSwitch(LoggingLevelSwitch levelSwitch)
    {
        _levelSwitch = levelSwitch;
        return this;
    }

    public FileConfigBuilder WithBuffered(bool buffered)
    {
        _buffered = buffered;
        return this;
    }

    public FileConfigBuilder WithShared(bool shared)
    {
        _shared = shared;
        return this;
    }

    public FileConfigBuilder WithFlushToDiskInterval(TimeSpan flushToDiskInterval)
    {
        _flushToDiskInterval = flushToDiskInterval;
        return this;
    }
    public FileConfigBuilder WithRollingInterval(RollingInterval rollingInterval)
    {
        _rollingInterval = rollingInterval;
        return this;
    }
    public FileConfigBuilder WithRollOnFileSizeLimit(bool rollOnFileSizeLimit)
    {
        _rollOnFileSizeLimit = rollOnFileSizeLimit;
        return this;
    }

    public FileConfigBuilder WithRetainedFileCountLimit(int retainedFileCountLimit)
    {
        _retainedFileCountLimit = retainedFileCountLimit;
        return this;
    }

    public FileConfigBuilder WithEncoding(Encoding encoding)
    {
        _encoding = encoding;
        return this;
    }

    public FileConfigBuilder WithFileLifecycleHooks(FileLifecycleHooks hooks)
    {
        _hooks = hooks;
        return this;
    }

    public FileConfigBuilder WithRetainedFileTimeLimit(TimeSpan retainedFileTimeLimit)
    {
        _retainedFileTimeLimit = retainedFileTimeLimit;
        return this;
    }


    internal void Build(LoggerConfiguration loggerConfiguration, string outputTemplate)
    {
        loggerConfiguration.WriteTo
            .File(_path, _restrictedToMinimumLevel,
                
                string.IsNullOrWhiteSpace(_outputTemplate)? outputTemplate:_outputTemplate, _formatProvider, _fileSizeLimitBytes
                , _levelSwitch, _buffered, _shared, _flushToDiskInterval, _rollingInterval, _rollOnFileSizeLimit,
                _retainedFileCountLimit
                , _encoding, _hooks, _retainedFileTimeLimit);
    }
}