using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebForum
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				// NOTE: to use Azure web-app storage see:
				// https://docs.microsoft.com/en-us/azure/azure-app-configuration/quickstart-aspnet-core-app?tabs=core5x

				// Doesn't work: I won't make a temp Azure account just for this minor personal project.

				//.ConfigureWebHostDefaults(webBuilder =>
				//	webBuilder.ConfigureAppConfiguration(config =>
				//	{
				//		var settings = config.Build();
				//		var connection = settings.GetConnectionString("AppConfig");
				//		config.AddAzureAppConfiguration(connection);
				//	}).UseStartup<Startup>());

				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}
