using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TrickingLibrary.API
{
    public class Startup
    {
        private const string AllCors = "All";
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();


            services.AddCors(options => options.AddPolicy(AllCors, build => build.AllowAnyOrigin().
                                                                                AllowAnyHeader().
                                                                                AllowAnyMethod()));
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

           
            app.UseRouting();

            app.UseCors(AllCors);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
