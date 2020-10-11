using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//using LGA.API.Core;
//using LGA.API.ViewModels.Mappings;
using LGA.API.Data;
using LGA.API.Data.Contracts;
using LGA.API.Data.Repositories;
using System.Net;

namespace LGA.API
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string sqlConnectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<LGAContext>(options =>
            {
                options.UseSqlServer(sqlConnectionString,
                    b => b.MigrationsAssembly("LGA.API"));
            });
            services.AddScoped<IStateRepository, StateRepository>();
            services.AddScoped<IScoreRepository, ScoreRepository>();
            //AutoMapperConfiguration.Configure();
            services.AddMvc(options => options.EnableEndpointRouting = false);            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();            
            app.UseExceptionHandler(
                builder =>
            {
                    builder.Run(
                        async context =>
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            var error = context.Features.Get<IExceptionHandlerFeature>();
                            if (error != null)
                            {
                                context.Response.Headers["headererror"] = error.Error.Message;
                                await context.Response.WriteAsync(error.Error.Message).ConfigureAwait(false);
            }
                        });
                });
            app.UseMvc(routes =>
              {
                  routes.MapRoute(
                      name: "default",
                      template: "{controller=Home}/{action=Index}/{id?}");
              });
            LGADbInitializer.Initialize(app.ApplicationServices);
        }
    }
}
