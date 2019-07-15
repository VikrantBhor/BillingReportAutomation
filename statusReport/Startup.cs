using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using statusReport.Common;
using statusReport.Models;
using statusReport.Services;
using statusReport.Services.Implementation;

namespace statusReport
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.Add(new ServiceDescriptor(typeof(actitimeContext), new actitimeContext(Configuration.GetConnectionString("DefaultConnection"))));
            services.AddOptions();
            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
            services.Configure<ManagerSettings>(Configuration.GetSection("ManagerSettings"));
            services.AddScoped<IEmailSender, EmailSender>();

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                // app.UseHsts();
            }

            //var options = new RewriteOptions()
            //   .AddRedirectToHttps(StatusCodes.Status301MovedPermanently, 49203);
            //app.UseRewriter(options);

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            // app.UseCors("AzurePolicy");

            app.UseAuthentication();



            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller = Home}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });

        }
    }
}
