using System;
using System.IO;
using DataReceiving;
using InMemoryReceiver;
using JsonSerializer.Serialization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serialization;
using TextFileReceiver;
using XDomWriter.Serialization;
using XmlSerializer.Serialization;
using Microsoft.Extensions.Logging;

namespace ConsoleClient
{
    /// <summary>
    /// Extension methods for service collection.
    /// </summary>
    internal static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add custom services to service collection.
        /// </summary>
        /// <param name="services">Source service collection.</param>
        /// <param name="configuration">The application configuration.</param>
        /// <param name="format">The data format.</param>
        /// <param name="mode">The data mode.</param>
        /// <returns>Returned service collection.</returns>
        public static IServiceCollection UseExportDataServices(this IServiceCollection services, IConfiguration configuration, string format, string mode)
        {
            string path = Directory.GetCurrentDirectory();

            string txtPath = Path.Combine(path, configuration["textFilePath"]) ?? throw new ArgumentNullException(configuration["textFilePath"]);
            string xmlPath = Path.Combine(path, configuration["xmlFilePath"]) ?? throw new ArgumentNullException(configuration["xmlFilePath"]);
            string jsonPath = Path.Combine(path, configuration["jsonFilePath"]) ?? throw new ArgumentNullException(configuration["jsonFilePath"]);

            return format switch
            {
                "xml" when mode == "inFile" => services
                    .AddTransient<IDataReceiver>(_ => new TextStreamReceiver(txtPath))
                    .AddTransient<IDataSerializer<Uri>, XDomTechnology>(provider =>
                        new XDomTechnology(xmlPath, provider.GetService<ILogger<XDomTechnology>>()))
                    .AddTransient<IDataSerializer<Uri>, XmlSerializerTechnology>(provider =>
                        new XmlSerializerTechnology(xmlPath, provider.GetService<ILogger<XmlSerializerTechnology>>())),
                "xml" when mode == "inMemory" => services
                    .AddTransient<IDataReceiver>(_ => new InMemoryDataReceiver())
                    .AddTransient<IDataSerializer<Uri>, XDomTechnology>(provider =>
                        new XDomTechnology(xmlPath, provider.GetService<ILogger<XDomTechnology>>())),
                "json" when mode == "inFile" => services
                    .AddTransient<IDataReceiver>(_ => new TextStreamReceiver(txtPath))
                    .AddTransient<IDataSerializer<Uri>, JsonSerializerTechnology>(provider =>
                        new JsonSerializerTechnology(jsonPath,
                            provider.GetService<ILogger<JsonSerializerTechnology>>())),
                "json" when mode == "inMemory" => services
                    .AddTransient<IDataReceiver>(_ => new InMemoryDataReceiver())
                    .AddTransient<IDataSerializer<Uri>, JsonSerializerTechnology>(provider =>
                        new JsonSerializerTechnology(jsonPath,
                            provider.GetService<ILogger<JsonSerializerTechnology>>())),
                _ => throw new ArgumentException(format, nameof(format), null)
            };
        }
    }
}
