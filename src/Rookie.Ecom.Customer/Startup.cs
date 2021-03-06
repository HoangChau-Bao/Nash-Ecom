using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rookie.Ecom.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4;
using IdentityServer4.Configuration;
using Microsoft.AspNetCore.Authentication;

namespace Rookie.Ecom.Customer
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
            services.AddHttpContextAccessor();
            services.AddBusinessLayer(Configuration);

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
            .AddCookie("Cookies", options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                options.SlidingExpiration = true;
            }
            )
            .AddOpenIdConnect("oidc", options =>
            {
                options.CallbackPath = "/signin-oidc";
                options.SignInScheme = "Cookies";
                options.Authority = "https://localhost:5001/";
                options.RequireHttpsMetadata = true;

                options.ClientId = "rookieecomcustomer";
                options.ClientSecret = "rookieecomcustomer";
                options.ResponseType = "id_token token";

                options.SaveTokens = true;
                options.ClaimActions.MapUniqueJsonKey("role", "role");
                options.GetClaimsFromUserInfoEndpoint = true;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    RoleClaimType = "role",
                    NameClaimType = "given_name" + " " + "family_name"
                };
                options.Scope.Add("profile");
                options.Scope.Add("roles");
                options.Scope.Add("openid");
            });
        }

        private static void SetupIdentityServer(IdentityServerOptions options)
        {
            options.UserInteraction.LoginUrl = "/auth/login";
            options.UserInteraction.LoginReturnUrlParameter = "returnUrl";
            options.UserInteraction.LogoutUrl = "/logout";
            options.UserInteraction.ErrorUrl = "/error/identity";

            options.Events.RaiseErrorEvents = true;
            options.Events.RaiseInformationEvents = true;
            options.Events.RaiseFailureEvents = true;
            options.Events.RaiseSuccessEvents = true;

            // see https://identityserver4.readthedocs.io/en/latest/topics/resources.html
            //options.EmitStaticAudienceClaim = true;
            //identityServerOptions.Authentication.CookieLifetime = TimeSpan.FromDays(1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }

    }
}
