using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoLotDAL_Core2.DataInitialization;
using AutoLotDAL_Core2.EF;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AutoLotMVC_Core2
{
    public class Program
    {
        public static void Main(String[] args)
        {
            var webHost = BuildWebHost(args);
            using (var scope = webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<AutoLotContext>();
                MyDataInitializer.RecreateDatabase(context);
                MyDataInitializer.InitializeData(context);
            }
            webHost.Run();
        }

        public static IWebHost BuildWebHost(String[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
