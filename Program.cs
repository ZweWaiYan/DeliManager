// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Hosting;
// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.Hosting;
// using Microsoft.Extensions.Logging;

// namespace GolfCMS
// {
//     public class Program
//     {
//         public static void Main(string[] args)
//         {
//             CreateHostBuilder(args).Build().Run();
//         }

//         public static IHostBuilder CreateHostBuilder(string[] args) =>
//             Host.CreateDefaultBuilder(args)
//                 .ConfigureWebHostDefaults(webBuilder =>
//                 {
//                     webBuilder.UseStartup<Startup>();
//                 });
//     }
// }
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeliManager;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

// using System;
// using System.Collections.Generic;
// using System.IO;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore;
// using Microsoft.AspNetCore.Hosting;
// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.Logging;
// using NLog.Extensions.Logging;

namespace DeliManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        // public static IWebHostBuilder CreateHostBuilder(string[] args) =>
        //      WebHost.CreateDefaultBuilder(args)
        //      .ConfigureLogging((hostingContext, logging) =>
        //      {
        //          logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
        //          logging.AddConsole();
        //          logging.AddDebug();
        //          logging.AddEventSourceLogger();
        //          logging.AddNLog();
        //      }).UseKestrel(options =>
        //      {
        //          options.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(120);
        //          options.Limits.RequestHeadersTimeout = TimeSpan.FromMinutes(120);
        //          options.Limits.MaxRequestBodySize = 524288000;
        //      })
        //      .UseStartup<Startup>();
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            
         Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
            webBuilder
            .ConfigureLogging((hostingContext, logging) =>
            {
                logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                logging.AddConsole();
                logging.AddDebug();
                logging.AddEventSourceLogger();
                //logging.AddNLog();
            })
            .UseStartup<Startup>();
        });
        
    }
}

