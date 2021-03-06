﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace SampleWebAPICore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Add the below 2 lines of code for deploying to OpenShift
            var config = new ConfigurationBuilder().AddEnvironmentVariables("").Build();

            var url = config["ASPNETCORE_URLS"] ?? "http://*:8080";

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
