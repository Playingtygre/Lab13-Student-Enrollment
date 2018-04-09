using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Student_Enrollment.Models;

namespace Student_Enrollment
{
    public class Startup
    {
        //THIS IS NEEDED IN ORDER TO GET ENITY FRAMEWORK
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        //THIS IS NEEDED IN ORDER TO GET ENITY FRAMEWORK

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //This is the pipeline adding middle ware.
            services.AddMvc();

            services.AddDbContext<Student_EnrollmentContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("Student_EnrollmentContext")));

            //Need to add link here
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            //use MVC pipeline/This also fires off first.
            app.UseMvc(routes =>
           {
               routes.MapRoute(
                   name: "default",
                   template: "{controller=Home}/{action=Index}/{id?}");

           });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });


        }


    }
}
