using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MuscleCarRent.Areas.Identity.Data;

[assembly: HostingStartup(typeof(MuscleCarRent.Areas.Identity.IdentityHostingStartup))]
namespace MuscleCarRent.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<MuscleCarRentContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("MuscleCarRentContext")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<MuscleCarRentContext>();
            });
        }
    }
}