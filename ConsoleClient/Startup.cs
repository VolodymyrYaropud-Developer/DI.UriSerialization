using System;
using System.IO;
using Conversion;
using ExportDataService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using UriConversion;
using Validation;

namespace ConsoleClient
{
    public class Startup
    {
        public IServiceProvider CreateServiceProvider()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            LogManager.Setup()
                .SetupExtensions(s => s.RegisterConfigSettings(configuration))
                .GetCurrentClassLogger();

            return new ServiceCollection()
                .AddTransient<IValidator<string>, UriValidator>()
                .AddTransient<IConverter<Uri?>, UriConverter>()
                .AddTransient<ExportDataService<Uri>>()
                .AddLogging(loggingBuilder =>
                {
                    loggingBuilder.ClearProviders();
                    loggingBuilder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                    loggingBuilder.AddNLog(configuration);
                })
                .UseExportDataServices(configuration, configuration["format"], configuration["mode"])
                .BuildServiceProvider();
        }
    }
}
