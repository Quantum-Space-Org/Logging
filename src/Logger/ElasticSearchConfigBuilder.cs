using System;
using Elasticsearch.Net;
using Serilog;
using Serilog.Sinks.Elasticsearch;

namespace Quantum.Logging;

public interface ILoggerConfigBuilder
{
    void Build(LoggerConfiguration loggerConfiguration);
}

public class ElasticSearchConfigBuilder
{
    public static ElasticSearchConfigBuilder IWantToConfigElasticSearch => new();

    private static Uri _defaultNode = new Uri("http://localhost:9002");
    string _indexFormat = "logstash-{0:yyyy.MM.dd}";
    string _deadLetterIndexName = "deadletter-{0:yyyy.MM.dd}";
    TimeSpan _period = TimeSpan.FromSeconds(2.0);
    int _batchPostingLimit = 50;
    long? _singleEventSizePostingLimit = null;
    string _typeName= null;
    string _templateName = "serilog-events-template";
    TimeSpan _connectionTimeout = TimeSpan.FromSeconds(5.0);
    EmitEventFailureHandling _emitEventFailure = EmitEventFailureHandling.WriteToSelfLog;
    RegisterTemplateRecovery _registerTemplateFailure = RegisterTemplateRecovery.IndexAnyway;
    long _queueSizeLimit = 100000;
    int? _bufferFileCountLimit = 31;
    long? _bufferFileSizeLimitBytes = 104857600L;
    bool _formatStackTraceAsArray = false;
    IConnectionPool _connectionPool = (IConnectionPool)new SingleNodeConnectionPool(_defaultNode, (IDateTimeProvider)null);

    private RollingInterval _bufferFileRollingInterval = RollingInterval.Day;

    public ElasticSearchConfigBuilder WithNodeUrl(string nodeUrl)
    {
        _defaultNode =new Uri(nodeUrl);
        return this;
    }

    public ElasticSearchConfigBuilder WithIndexFormat(string indexFormat)
    {
        _indexFormat = indexFormat;
        return this;
    }
    
    public ElasticSearchConfigBuilder WithTypeName(string typeName)
    {
        _typeName = typeName;
        return this;
    }

    public ElasticSearchConfigBuilder WithPeriod(TimeSpan period)
    {
        _period = period;
        return this;
    }
    public ElasticSearchConfigBuilder WithBatchPostingLimit(int batchPostingLimit)
    {
        _batchPostingLimit = batchPostingLimit;
        return this;
    }
    public ElasticSearchConfigBuilder WithSingleEventSizePostingLimit(long singleEventSizePostingLimit)
    {
        _singleEventSizePostingLimit = singleEventSizePostingLimit;
        return this;
    }
    public ElasticSearchConfigBuilder WithTemplateName(string templateName)
    {
        _templateName = templateName;
        return this;
    }

    public ElasticSearchConfigBuilder WithConnectionTimeout(TimeSpan connectionTimeout)
    {
        _connectionTimeout = connectionTimeout;
        return this;
    }

    public ElasticSearchConfigBuilder WithEmitEventFailure(EmitEventFailureHandling emitEventFailure)
    {
        _emitEventFailure = emitEventFailure;
        return this;
    }

    public ElasticSearchConfigBuilder WithRegisterTemplateFailure(RegisterTemplateRecovery registerTemplateFailure)
    {
        _registerTemplateFailure = registerTemplateFailure;
        return this;
    }

    public ElasticSearchConfigBuilder WithQueueSizeLimit(long queueSizeLimit)
    {
        _queueSizeLimit = queueSizeLimit;
        return this;
    }
    public ElasticSearchConfigBuilder WithBufferFileCountLimit(int bufferFileCountLimit)
    {
        _bufferFileCountLimit = bufferFileCountLimit;
        return this;
    }

    public ElasticSearchConfigBuilder WithBufferFileSizeLimitBytes(long bufferFileSizeLimitBytes)
    {
        _bufferFileSizeLimitBytes = bufferFileSizeLimitBytes;
        return this;
    }

    public ElasticSearchConfigBuilder WithFormatStackTraceAsArray(bool formatStackTraceAsArray)
    {
        _formatStackTraceAsArray  = formatStackTraceAsArray;
        return this;
    }
    public ElasticSearchConfigBuilder WithBufferFileRollingInterval(RollingInterval bufferFileRollingInterval)
    {
        _bufferFileRollingInterval = bufferFileRollingInterval;
        return this;
    }

    internal void Build(LoggerConfiguration loggerConfiguration)
    {
        loggerConfiguration.WriteTo.Elasticsearch(_defaultNode.ToString()
            , _indexFormat, _templateName, _typeName, _batchPostingLimit, _batchPostingLimit);
    }
}