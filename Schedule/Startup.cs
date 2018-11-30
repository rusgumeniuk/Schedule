using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

using Schedule.Models.Contexts;

namespace Schedule
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {            
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<BuildContext>(options => options.UseSqlServer(connection));
            services.AddDbContext<RoomContext>(options => options.UseSqlServer(connection));
            services.AddDbContext<TeacherContext>(options => options.UseSqlServer(connection));
            services.AddDbContext<SubjectContext>(options => options.UseSqlServer(connection));
            services.AddDbContext<GroupContext>(options => options.UseSqlServer(connection));
            services.AddDbContext<LessonContext>(options => options.UseSqlServer(connection));

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
