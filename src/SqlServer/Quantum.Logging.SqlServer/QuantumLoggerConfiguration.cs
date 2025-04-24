namespace Quantum.Logging.SqlServer;

public static class QuantumLoggerConfigurations
{
    public static QuantumLoggerConfiguration LogToSqlServer(this QuantumLoggerConfiguration config, MsSqlServerConfigBuilder builder)
    {
        config. _msSqlServerConfigBuilder = builder;
        return config;
    }
}