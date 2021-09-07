using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using Serilog.Sinks.MSSqlServer.Sinks.MSSqlServer.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevReviews.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                //adicionando o log
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var setings = config.Build();

                    Serilog.Log.Logger = new LoggerConfiguration()
                    .WriteTo.MSSqlServer(
                        setings.GetValue<string>("DevReviewsCn"),
                        sinkOptions: new MSSqlServerSinkOptions()
                        {
                            TableName = "Logs",
                            AutoCreateSqlTable = true
                        })
                        .CreateLogger();
                })
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void hostingContext(HostBuilderContext arg1, IConfigurationBuilder arg2)
        {
            throw new NotImplementedException();
        }
    }
}
