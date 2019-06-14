using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using System;

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
            //services.AddAuthorization();

            //adding the azure authentication
            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = OpenIdConnectDefaults.AuthenticationScheme;
            //    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //})
            //.AddOpenIdConnect(options =>
            //{
            //    options.Authority = "https://login.microsoftonline.com/74c3a4b1-a2a5-4e48-9d7b-434f36d335ed";
            //    //options.Authority = "https://login.microsoftonline.com/74c3a4b1-a2a5-4e48-9d7b-434f36d335ed/v2.0/.well-known/openid-configuration";
            //    options.ClientId = "95becc1f-0f6d-4da6-aa19-c2057867e3bd";
            //    options.ResponseType = OpenIdConnectResponseType.IdToken;
            //    //options.CallbackPath = "/auth/signin-callback";
            //    options.CallbackPath = "/report";
            //    options.SignedOutRedirectUri = "http://localhost:49203";
            //    options.TokenValidationParameters.NameClaimType = "name";
                
            //})
            //.AddCookie();

            //services.AddCors((options =>
            //{
            //    options.AddPolicy("AzurePolicy", builder => builder
            //                .WithOrigins()
            //                .AllowAnyMethod()
            //                .AllowAnyHeader()
            //                .AllowCredentials()
            //     );
            //}));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


            // In production, the Angular files will be served from this directory
            //services.AddSpaStaticFiles(configuration =>
            //{
            //    configuration.RootPath = "ClientApp/dist";
            //});
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
           // app.UseSpaStaticFiles();

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
