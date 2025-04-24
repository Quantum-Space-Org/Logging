using System;
using System.Net.Http;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace Quantum.Logging;

/// <summary>
/// Write log events to a <a href="https://datalust.co/seq">Seq</a> server.
/// </summary>
/// <param name="loggerSinkConfiguration">The logger configuration.</param>
/// <param name="serverUrl">The base URL of the Seq server that log events will be written to.</param>
/// <param name="restrictedToMinimumLevel">The minimum log event level required
/// in order to write an event to the sink.</param>
/// <param name="batchPostingLimit">The maximum number of events to post in a single batch.</param>
/// <param name="period">The time to wait between checking for event batches.</param>
/// <param name="bufferBaseFilename">Path for a set of files that will be used to buffer events until they
/// can be successfully transmitted across the network. Individual files will be created using the
/// pattern <paramref name="bufferBaseFilename" />*.json, which should not clash with any other filenames
/// in the same directory.</param>
/// <param name="apiKey">A Seq <i>API key</i> that authenticates the client to the Seq server.</param>
/// <param name="bufferSizeLimitBytes">The maximum amount of data, in bytes, to which the buffer
/// log file for a specific date will be allowed to grow. By default no limit will be applied.</param>
/// <param name="eventBodyLimitBytes">The maximum size, in bytes, that the JSON representation of
/// an event may take before it is dropped rather than being sent to the Seq server. Specify null for no limit.
/// The default is 265 KB.</param>
/// <param name="controlLevelSwitch">If provided, the switch will be updated based on the Seq server's level setting
/// for the corresponding API key. Passing the same key to MinimumLevel.ControlledBy() will make the whole pipeline
/// dynamically controlled. Do not specify <paramref name="restrictedToMinimumLevel" /> with this setting.</param>
/// <param name="messageHandler">Used to construct the HttpClient that will send the log messages to Seq.</param>
/// <param name="retainedInvalidPayloadsLimitBytes">A soft limit for the number of bytes to use for storing failed requests.
/// The limit is soft in that it can be exceeded by any single error payload, but in that case only that single error
/// payload will be retained.</param>
/// <param name="queueSizeLimit">The maximum number of events that will be held in-memory while waiting to ship them to
/// Seq. Beyond this limit, events will be dropped. The default is 100,000. Has no effect on
/// durable log shipping.</param>
/// <returns>Logger configuration, allowing configuration to continue.</returns>
/// <exception cref="T:System.ArgumentNullException">A required parameter is null.</exception>
///
/// 
public class SeqConfigBuilder
{
    public static SeqConfigBuilder WantToConfigSeq => new();


    private string _serverUrl;
    private LogEventLevel _restrictedToMinimumLevel = LogEventLevel.Verbose;
    private int _batchPostingLimit = 1000;
    private TimeSpan? _period = null;
    private string? _apiKey = null;
    private string? _bufferBaseFilename = null;
    private readonly long? _bufferSizeLimitBytes = null;
    private long? _eventBodyLimitBytes = 262144;
    private LoggingLevelSwitch? _controlLevelSwitch = null;
    private HttpMessageHandler? _messageHandler = null;
    private long? _retainedInvalidPayloadsLimitBytes = null;
    private int _queueSizeLimit = 100000;


    public SeqConfigBuilder WithServerUrl(string serverUrl)
    {
        _serverUrl= serverUrl;
        return this;
    }
        
    public SeqConfigBuilder WithLogEventLevel(LogEventLevel level)
    {
        _restrictedToMinimumLevel = level;
        return this;
    }

    public SeqConfigBuilder WithBatchPostingLimit(int batchPostingLimit)
    {
        _batchPostingLimit = batchPostingLimit;
        return this;
    }
    public SeqConfigBuilder WithPeriod(TimeSpan period)
    {
        _period = period;
        return this;
    }
    public SeqConfigBuilder WithApiKey(string apiKey)
    {
        _apiKey = apiKey;
        return this;
    }

    public SeqConfigBuilder WithBufferBaseFilename(string bufferBaseFilename)
    {
        _bufferBaseFilename = bufferBaseFilename;
        return this;
    }

    public SeqConfigBuilder WithEventBodyLimitBytes(long eventBodyLimitBytes)
    {
        _eventBodyLimitBytes = eventBodyLimitBytes;
        return this;
    }

    public SeqConfigBuilder WithLoggingLevelSwitch(LoggingLevelSwitch level)
    {
        _controlLevelSwitch = level;
        return this;
    }
    public SeqConfigBuilder WithRetainedInvalidPayloadsLimitBytes(long retainedInvalidPayloadsLimitBytes)
    {
        _retainedInvalidPayloadsLimitBytes = retainedInvalidPayloadsLimitBytes;
        return this;
    }
        
    public SeqConfigBuilder WithQueueSizeLimit(int queueSizeLimit)
    {
        _queueSizeLimit = queueSizeLimit;
        return this;
    }

    internal void Build(LoggerConfiguration loggerConfiguration)
    {
        loggerConfiguration.WriteTo.Seq(_serverUrl,_restrictedToMinimumLevel
        ,_batchPostingLimit,_period,_apiKey,_bufferBaseFilename,_bufferSizeLimitBytes,_eventBodyLimitBytes,_controlLevelSwitch,retainedInvalidPayloadsLimitBytes:_retainedInvalidPayloadsLimitBytes
        ,queueSizeLimit:_queueSizeLimit);
    }
}