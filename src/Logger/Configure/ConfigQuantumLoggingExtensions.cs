using Microsoft.Extensions.DependencyInjection;
using Quantum.Configurator;
using Quantum.Logging.Adapter;

namespace Quantum.Logging.Configure
{
    public static class ConfigQuantumLoggingExtensions
    {
        public static ConfigQuantumLoggingBuilder ConfigQuantumLogging(this QuantumServiceCollection collection)
        {
            return new ConfigQuantumLoggingBuilder(collection);
        }
    }

    public class ConfigQuantumLoggingBuilder
    {
        private readonly QuantumServiceCollection _quantumServiceCollection;

        public ConfigQuantumLoggingBuilder(QuantumServiceCollection collection)
        {
            _quantumServiceCollection = collection;
        }


        public ConfigQuantumLoggingBuilder ConfigLogging(QuantumLoggerConfiguration configuration)
        {
            configuration.ThankYou();
            return this;
        }

        public ConfigQuantumLoggingBuilder AddLoggerAdapter()
        {
            _quantumServiceCollection.Collection.AddSingleton<ILoggerAdapter, LoggerAdapter>();
            return this;
        }

        public ConfigQuantumLoggingBuilder AddLoggerAdapter(ILoggerAdapter adapter)
        {
            _quantumServiceCollection.Collection.AddSingleton<ILoggerAdapter>(adapter);
            return this;
        }


        public QuantumServiceCollection and()
        {
            return _quantumServiceCollection;
        }

    }
}
