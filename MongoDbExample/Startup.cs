using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDbExample.Entities;
using MongoDbExample.Services;

namespace MongoDbExample
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
            services.Configure<SchoolDatabaseSettings>(Configuration.GetSection(nameof(SchoolDatabaseSettings)));
            services.AddSingleton<ISchoolDatabaseSettings>(provider => provider.GetRequiredService<IOptions<SchoolDatabaseSettings>>().Value);
            services.AddScoped<StudentService>();
            services.AddScoped<CourseService>();
            services.AddControllers();
            services.AddAuthentication();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            app.UseRouting();



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
