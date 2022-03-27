using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace SG_Net_Challenge
{
    public class Program
    {
    
        public static void Main(string[] args)
        {
      
            CreateHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
         WebHost.CreateDefaultBuilder(args)
         .UseStartup<Startup>()
         .UseSerilog(ConfigureLogging);

        private static void ConfigureLogging(WebHostBuilderContext hostingContext, LoggerConfiguration loggerConfiguration)
        {
            loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration);
            Directory.CreateDirectory("App_Data/Logs");
            Serilog.Debugging.SelfLog.Enable(new StreamWriter("App_Data/Logs/serilog-failures.txt", true));
        }
    }
}
