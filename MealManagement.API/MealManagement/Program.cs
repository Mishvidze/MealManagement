using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MealManagement.Common;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MealManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {

            try
            {
                //MyLogger.LogInfo($"Cucuna - {DateTime.Now.ToShortTimeString()}");
                CreateWebHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                //MyLogger.LogException(ex, "Stopped program because of exception");
                throw;
            }
            finally
            {
                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                //NLog.LogManager.Shutdown();
            }

            //CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();


    }
}
