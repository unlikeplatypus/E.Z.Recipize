using EZRecipize.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;
using System;

[assembly: HostingStartup(typeof(EZRecipize.Areas.Identity.IdentityHostingStartup))]
namespace EZRecipize.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<EZRecipizeContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("EZRecipizeContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
               .AddEntityFrameworkStores<EZRecipizeContext>();

                services.AddControllersWithViews();
                services.AddRazorPages();
            });
        }

    }
}