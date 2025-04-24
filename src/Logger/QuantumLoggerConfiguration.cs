using Serilog;
using Serilog.Events;

namespace Quantum.Logging
{
    public class QuantumLoggerConfiguration
    {
        private string _outputTemplate = "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} " + "(";

        private readonly LoggerConfiguration _loggerConfiguration;
        private ConsoleConfigBuilder _consoleConfigBuilder;
        private FileConfigBuilder _fileConfigBuilder;
        private ElasticSearchConfigBuilder _elasticSearchConfigBuilder;
        public ILoggerConfigBuilder _msSqlServerConfigBuilder;
        private SeqConfigBuilder _seqConfigBuilder;
        private EnrichBuilder _enricher;

        private QuantumLoggerConfiguration(LoggerConfiguration loggerConfiguration)
            => _loggerConfiguration = loggerConfiguration;
        public static QuantumLoggerConfiguration IWantTo() => new(new LoggerConfiguration());

        public QuantumLoggerConfiguration LogToConsole(ConsoleConfigBuilder builder)
        {
            _consoleConfigBuilder = builder;

            return this;
        }

        public QuantumLoggerConfiguration LogToFile(FileConfigBuilder builder)
        {
            _fileConfigBuilder = builder;

            return this;
        }
        public QuantumLoggerConfiguration LogToElasticSearch(ElasticSearchConfigBuilder builder)
        {
            _elasticSearchConfigBuilder = builder;

            return this;
        }

        //public QuantumLoggerConfiguration LogToSqlServer(MsSqlServerConfigBuilder builder)
        //{
        //    _msSqlServerConfigBuilder = builder;
        //    return this;
        //}

        public QuantumLoggerConfiguration WithThisConfiguration(LogEventLevel logLevel)
        {
            _loggerConfiguration.MinimumLevel.Is(logLevel);
            return this;
        }

        public QuantumLoggerConfiguration LogToSeq(SeqConfigBuilder builder)
        {
            _seqConfigBuilder = builder;
            return this;
        }

        public QuantumLoggerConfiguration Enrich(EnrichBuilder enricher)
        {
            _enricher = enricher;
            return this;
        }

        public QuantumLoggerConfiguration WithApplication(string name, int instanceId)
        {
            _loggerConfiguration
                .Enrich.WithProperty("Application", name, true)
                .Enrich.WithProperty("ApplicationInstance", instanceId, true);

            return this;
        }

        public void ThankYou()
        {
            _outputTemplate = "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} (Application: {Application},ApplicationInstance:{ApplicationInstance}, " + "CorrelationId: {CorrelationId},";

            _enricher?.Enrich(_loggerConfiguration, ref _outputTemplate);

            _outputTemplate += "{Exception}{NewLine})";

            Build();

            _loggerConfiguration.Enrich.FromLogContext();

            Log.Logger = _loggerConfiguration.CreateBootstrapLogger();

            Log.Logger.Information("Logged");
        }

        private void Build()
        {
            _consoleConfigBuilder?.Build(_loggerConfiguration, _outputTemplate);

            _fileConfigBuilder?.Build(_loggerConfiguration, _outputTemplate);

            _elasticSearchConfigBuilder?.Build(_loggerConfiguration);

            _msSqlServerConfigBuilder?.Build(_loggerConfiguration);

            _seqConfigBuilder?.Build(_loggerConfiguration);
        }
    }
}