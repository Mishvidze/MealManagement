using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealManagement.Common;
using MealManagement.Data;
using MealManagement.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace MealManagement
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }

        public IConfiguration _config { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            SetUpLoggerConfig();

            SetUpAuthentication(services);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private void SetUpLoggerConfig()
        {
            var defaultConnection = _config.GetConnectionString("MealManagement");
            NLog.GlobalDiagnosticsContext.Set("defaultConnection", defaultConnection);
        }

        private void SetUpAuthentication(IServiceCollection services)
        {
            services.AddDbContext<MealManagementContext>(x => x.UseSqlServer(_config.GetConnectionString("MealManagement")));

            IdentityBuilder identityBuilder = services.AddIdentityCore<User>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            });

            identityBuilder = new IdentityBuilder(identityBuilder.UserType, typeof(Role), identityBuilder.Services);

            identityBuilder.AddRoleValidator<RoleValidator<Role>>();
            identityBuilder.AddRoleManager<RoleManager<Role>>();
            identityBuilder.AddSignInManager<SignInManager<User>>();
        }
    }
}
