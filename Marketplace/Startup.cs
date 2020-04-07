using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore;

namespace Marketplace
{
    public class Startup
    {
        private IConfiguration configuration { get; }
        private IWebHostEnvironment environment { get; }

        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            this.environment = environment;
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddMvcOptions(x => x.EnableEndpointRouting = false);
            services.AddSwaggerGen(
                x => x.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "ClassifiedAds",
                        Version = "v1"
                    }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvcWithDefaultRoute();
            app.UseSwagger();
            app.UseSwaggerUI(
                x => x.SwaggerEndpoint(
                    "/swagger/v1/swagger.json",
                    "ClassifiedAds v1"));
        }
    }
}
