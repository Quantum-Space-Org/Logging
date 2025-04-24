using Serilog;
using Serilog.Exceptions;

namespace Quantum.Logging;

public class EnrichBuilder
{
    private bool _showMachineName;
    private bool _showUserName;
    private bool _showEnvironmentName;
    private bool _showProcessName;
    private bool _showProcessId;
    private bool _showExceptionDetails;
    private bool _showThreadName;
    private bool _showThreadId;
    private string _defaultThreadName;
    private bool _showClientInfo;
    private string _headerName;
    private bool _addValueIfHeaderAbsence;

    public static EnrichBuilder IWantToEnrichLogs => new();

    public EnrichBuilder WithEnvironment(bool showMachineName, bool showUserName, bool showEnvironmentName)
    {
        _showMachineName = showMachineName;
        _showUserName = showUserName;
        _showEnvironmentName = showEnvironmentName;
        return this;
    }

    public EnrichBuilder WithProcess(bool showProcessName, bool showProcessId)
    {
        _showProcessName = showProcessName;
        _showProcessId = showProcessId;
        return this;
    }

    public EnrichBuilder WithThread(bool showThreadName, bool showThreadId, string defaultThreadName = "default-thread-name")
    {
        _showThreadName = showThreadName;
        _showThreadId = showThreadId;
        _defaultThreadName = defaultThreadName;
        return this;
    }
    public EnrichBuilder WithClientInfo(string headerName = "x-correlation-id",
        bool addValueIfHeaderAbsence = false)
    {
        _showClientInfo = true;
        _headerName = headerName;
        _addValueIfHeaderAbsence = addValueIfHeaderAbsence;
        return this;
    }

    public EnrichBuilder WithExceptionDetails()
    {
        _showExceptionDetails = true;
        return this;
    }

    internal void Enrich(LoggerConfiguration loggerConfiguration, ref string outputTemplate)
    {
        if (_showEnvironmentName)
        {
            loggerConfiguration.Enrich.WithEnvironmentName();
            outputTemplate += " EnvironmentName: {EnvironmentName}, ";
        }

        if (_showMachineName)
        {
            loggerConfiguration.Enrich.WithMachineName();
            outputTemplate += " MachineName: {MachineName}, ";
        }

        if (_showUserName)
        {
            loggerConfiguration.Enrich.WithEnvironmentUserName();
            outputTemplate += " EnvironmentUserName: {EnvironmentUserName}, ";
        }

        if (_showProcessId)
        {
            loggerConfiguration.Enrich.WithProcessId();
            outputTemplate += " Process: {ProcessId}, ";
        }

        if (_showProcessName)
        {
            loggerConfiguration.Enrich.WithProcessName();
            outputTemplate += " ProcessName: {ProcessName}, ";
        }

        if (_showExceptionDetails)
        {
            loggerConfiguration.Enrich.WithExceptionDetails();
            
            outputTemplate += " ExceptionDetail: {ExceptionDetail}, ";
        }


        if (_showThreadId)
        {
            loggerConfiguration.Enrich.WithThreadId();
            outputTemplate += "ThreadId:{ThreadId},";
        }

        if (_showThreadName)
        {
            loggerConfiguration.Enrich.WithThreadName();
            outputTemplate +=  "ThreadName:{ThreadName}," ;
        }

        if (_showClientInfo)
        {
            loggerConfiguration.Enrich.WithClientIp()
                .Enrich.WithRequestHeader(_headerName);
            outputTemplate += " ClientIp:{ClientIp},";
        }

        loggerConfiguration.Enrich.WithCorrelationId();
    }
}