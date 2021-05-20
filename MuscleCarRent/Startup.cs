using Domain.Repos;
using Infra;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using MuscleCarRentProject.Domain.Repos;
using MuscleCarRentProject.Infra;

namespace MuscleCarRent
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddDbContext<MuscleCarRentDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddTransient<IAccountsRepo, AccountRepo>();
            services.AddTransient<IBankCardsRepo, BankCardRepo>();
            services.AddTransient<ICarsRepo, CarsRepo>();
            services.AddTransient<IDriversRepo, DriverRepo>();
            services.AddTransient<IImagesRepo, ImageRepo>();
            services.AddTransient<IOrderedDatesRepo, OrderedDateRepo>();
            services.AddTransient<IOrderedRepo, OrderRepo>();
            services.AddTransient<IPromotionRepo, PromotionRepo>(); 

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
