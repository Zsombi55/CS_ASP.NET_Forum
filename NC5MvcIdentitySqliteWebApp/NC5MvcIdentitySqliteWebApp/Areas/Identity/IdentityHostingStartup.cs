using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NC5MvcIdentitySqliteWebApp.Data;

[assembly: HostingStartup(typeof(NC5MvcIdentitySqliteWebApp.Areas.Identity.IdentityHostingStartup))]
namespace NC5MvcIdentitySqliteWebApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}