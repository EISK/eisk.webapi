using Serilog;

namespace Eisk.WebApi.Configuration
{
    public static class Serilog
    {
        private static readonly Func<IConfigurationRoot, ConfigurationManager, LoggerConfiguration> _serilogConfig = (config, env)
            => new LoggerConfiguration()
                 .WriteTo.Seq(string.IsNullOrWhiteSpace(env["sqlServerUrl"]) ? "http://seq" : env["sqlServerUrl"])
                 .WriteTo.Http(requestUri: string.IsNullOrWhiteSpace(env["requestUri"]) ? "http://logstash:8080" : env["requestUri"], queueLimitBytes: null)
                 .ReadFrom.Configuration(config);

        private static readonly IConfigurationRoot _configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true)
                .Build();

        public static void AddSerilogConfig(this WebApplicationBuilder builder, ConfigurationManager env)
            => builder
                .Logging
                .AddSerilog(_serilogConfig(_configurationBuilder, env).CreateLogger());
    }
}
