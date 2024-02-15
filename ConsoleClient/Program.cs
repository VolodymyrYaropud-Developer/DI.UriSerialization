using System;
using ExportDataService;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleClient
{
    public static class Program
    {
        public static int Main()
        {
            var provider = new Startup().CreateServiceProvider();
            var service = provider.GetService<ExportDataService<Uri>>();
            service?.Run();
            return 0;
        }
    }
}
