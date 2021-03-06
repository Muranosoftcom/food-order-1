﻿using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace FoodOrder.WebUI {
    public class Program {
        public static void Main(string[] args) {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) {
            return WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .ConfigureAppConfiguration((hostingContext, config) => {
                    config.SetBasePath(Directory.GetCurrentDirectory());
                    config.AddJsonFile($"appsettings{(hostingContext.HostingEnvironment.IsProduction() ? ".production" : "")}.json", optional: false, reloadOnChange: true);
                    config.AddJsonFile($"secrets{(hostingContext.HostingEnvironment.IsProduction() ? ".production" : "")}.json", optional: false, reloadOnChange: true);
                    config.AddCommandLine(args);
                })
                .UseStartup<Startup>();
        }
    }
}