using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NC5MvcIdentitySqliteWebApp
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				//.ConfigureAppConfiguration((hostingContext, config) =>
				//{
				//	config.AddJsonFile();
				//	config.AddEnvironmentVariables(prefix: "MyCustomPrefix_");
				//})
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}

/* TODO: 1: for this, would have to set up a new "Environment Variable", look for "IConfigurationProvider", lesson 27 last half, and 28 (0:05:00 ~ 1:14:00) "Custom Configurations".
 *
 * TODO: 2: add GitHub link to project in "./ Views/ Shared/ _Layout" through a configuration file.
 */