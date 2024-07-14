using System;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using DeliManager.Common;
using DeliManager.DataAccess;
using DeliManager.Controllers;

//using NLog.Web;

namespace DeliManager
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
            //using var loggerFactory = LoggerFactory.Create(builder =>
            //{
            //    builder.SetMinimumLevel(LogLevel.Information);
            //    builder.AddConsole();
            //    builder.AddEventSourceLogger();
            //});
            //var logger = loggerFactory.CreateLogger("Startup");
            //logger.LogInformation("Hello World, this is my log");
            // NLog.Logger mLog = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            //mLog.Info("Configure Services...");
            services.AddHttpContextAccessor();
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddDistributedMemoryCache();
            //below line used in FIGW , required namespace in request xml. xml fields must be exact order.
            //services.AddControllers().AddXmlDataContractSerializerFormatters(); 
            services.AddControllers().AddXmlSerializerFormatters();
            var tokenKey = Configuration.GetValue<string>("TokenKey");
            var key = Encoding.ASCII.GetBytes(tokenKey);

            //services.AddMvc(option => option.EnableEndpointRouting = false)
            //    //.AddXmlDataContractSerializerFormatters()
            //    .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                // options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                //options.IdleTimeout = TimeSpan.FromSeconds(60);
               // options.IdleTimeout = TimeSpan.FromMinutes(2); //20Mins
                 options.IdleTimeout = TimeSpan.FromSeconds(10800); // 180Mins
                //  options.IdleTimeout = TimeSpan.FromDays(7); // 180Mins
                options.Cookie.HttpOnly = true;
                // Make the session cookie essential
                options.Cookie.IsEssential = true;
            });
            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSpaStaticFiles();

            app.UseRouting();
            app.UseSession();

            app.UseAuthentication();
            app.UseAuthorization();

            // ================>

            //Cron To Test Every Minutes  0 * * ? * *
            // RecurringJob.AddOrUpdate<CBMMIS_Web.Services.ICBMReportService>(x => x.DoSendReportTemplate(), "0 * * ? * *"); // every minute
            // RecurringJob.AddOrUpdate<CBMMIS_Web.Services.ICBMReportService>(x => x.DoCheckReportStatus(), "0 * * ? * *"); // every minue
            // RecurringJob.AddOrUpdate<CBMMIS_Web.Services.ICBMReportService>(x => x.DoUpdateAuthenticationToken(), "0 0 */12 ? * *"); // 0 0 */12 ? * * 	Every twelve hours  or every day 8 AM.
            // <================

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller}/{action=Index}/{id?}");
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}