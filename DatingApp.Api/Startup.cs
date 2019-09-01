using DatingApp.Api.Extensions;
using DatingApp.Api.Filters;
using DatingApp.Api.Middlewares;
using DatingApp.Database;
using DatingApp.Domain.Contracts.Users;
using DatingApp.Domain.Models.Configurations;
using DatingApp.Repositories.Users;
using DatingApp.Services.UserServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DatingApp.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }

            app.UseExceptionHandler("/error");
            app.UseMiddleware<ErrorHandlingMiddleware>();
            //app.UseHttpsRedirection();
            app.UseCors("DefaultCorsPolicy");
            app.UseMvc();
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<DatabaseContext>().Database.Migrate();

            }
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSetting>(Configuration.GetSection("ApplicationSettings"));
            var appSetting = Configuration.GetSection("ApplicationSettings").Get<AppSetting>();

            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(appSetting.ConnectionStrings.Default));

            services.AddMvc(o => { o.Filters.Add<ValidateModelAttribute>(int.MinValue); });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddMvc(o => { o.UseGeneralRoutePrefix("api/v{version:apiVersion}"); });
            services.AddApiVersioning(o => o.ReportApiVersions = true);
            services.AddOptions();
            services.AddCors(options =>
            {
                options.AddPolicy("DefaultCorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IAuthService, AuthService>();

        }
    }
}
