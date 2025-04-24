using System;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using Serilog.Formatting;
using Serilog.Sinks.MSSqlServer;

namespace Quantum.Logging;

/// <summary>
/// Adds a sink that writes log events to a table in a MSSqlServer database.
/// Create a database and execute the table creation script found here
/// https://gist.github.com/mivano/10429656
/// or use the autoCreateSqlTable option.
/// </summary>
/// <param name="loggerConfiguration">The logger configuration.</param>
/// <param name="connectionString">The connection string to the database where to store the events.</param>
/// <param name="sinkOptions">Supplies additional settings for the sink</param>
/// <param name="sinkOptionsSection">A config section defining additional settings for the sink</param>
/// <param name="appConfiguration">Additional application-level configuration. Required if connectionString is a name.</param>
/// <param name="restrictedToMinimumLevel">The minimum level for events passed through the sink. Ignored when LevelSwitch in <paramref name="sinkOptions" /> is specified.</param>
/// <param name="formatProvider">Supplies culture-specific formatting information, or null.</param>
/// <param name="columnOptions">An externally-modified group of column settings</param>
/// <param name="columnOptionsSection">A config section defining various column settings</param>
/// <param name="logEventFormatter">Supplies custom formatter for the LogEvent column, or null</param>
/// <returns>Logger configuration, allowing configuration to continue.</returns>
/// <exception cref="T:System.ArgumentNullException">A required parameter is null.</exception>
public class MsSqlServerConfigBuilder : ILoggerConfigBuilder
{
    public static MsSqlServerConfigBuilder WantToConfigMsSqlServer => new();

    private string _connectionString;
    private MSSqlServerSinkOptions _sinkOptions = null;
    private IConfigurationSection _sinkOptionsSection = null;
    private IConfiguration _appConfiguration = null;
    private LogEventLevel _restrictedToMinimumLevel = LogEventLevel.Verbose;
    private IFormatProvider _formatProvider = null;
    private ColumnOptions _columnOptions = null;
    private IConfigurationSection _columnOptionsSection = null;
    private ITextFormatter _logEventFormatter = null;


    public MsSqlServerConfigBuilder WithConnectionString(string connectionString)
    {
        _connectionString = connectionString;
        return this;
    }

    public MsSqlServerConfigBuilder WithMsSqlServerSinkOptions(MSSqlServerSinkOptions sinkOptions)
    {
        _sinkOptions = sinkOptions;
        return this;
    }
    public MsSqlServerConfigBuilder WithSinkOptionsSection(IConfigurationSection sinkOptionsSection)
    {
        _sinkOptionsSection = sinkOptionsSection;
        return this;
    }
    public MsSqlServerConfigBuilder WithConfiguration(IConfiguration appConfiguration)
    {
        _appConfiguration = appConfiguration;
        return this;
    }

    public MsSqlServerConfigBuilder WithStandardErrorFromLevel(LogEventLevel standardErrorFromLevel)
    {
        _restrictedToMinimumLevel = standardErrorFromLevel;
        return this;
    }

    public MsSqlServerConfigBuilder WithFormatProvider(IFormatProvider formatProvider)
    {
        _formatProvider = formatProvider;
        return this;
    }

    public MsSqlServerConfigBuilder WithColumnOptions(ColumnOptions columnOptions)
    {
        _columnOptions = columnOptions;
        return this;
    }
    public MsSqlServerConfigBuilder WithColumnOptionsSection(IConfigurationSection columnOptionsSection)
    {
        _columnOptionsSection = columnOptionsSection;
        return this;
    }

    public MsSqlServerConfigBuilder WithLogEventFormatter(ITextFormatter logEventFormatter)
    {
        _logEventFormatter = logEventFormatter;
        return this;
    }


    public void Build(LoggerConfiguration loggerConfiguration)
    {
        loggerConfiguration.WriteTo.MSSqlServer(_connectionString, _sinkOptions
        , _sinkOptionsSection,
        _appConfiguration,
        _restrictedToMinimumLevel,
        _formatProvider,
        _columnOptions,
        _columnOptionsSection,
        _logEventFormatter);
    }
}