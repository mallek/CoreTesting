using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using OdeToFood.Services;
using OdeToFood.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Routing;

namespace OdeToFood
{
    public class Startup
    {
        
        public Startup(IHostingEnvironment env)  
        {
            if(env.EnvironmentName == "Production")
            {
                _isDevelopment = true;
            }
            
            var builder = new ConfigurationBuilder();
             
                builder.SetBasePath(env.ContentRootPath);
                
                builder.AddJsonFile("wwwroot\\appsettings.json", optional: true, reloadOnChange: true);
                
                builder.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

                       
            Configuration = builder.Build();
        }
        
        public IConfiguration Configuration {get;set;}  
        private bool _isDevelopment {get;set;}
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            
            var connection = @"Server=(localdb)\mssqllocaldb;Database=EFGetStarted.AspNetCore.NewDb;Trusted_Connection=True;";
            services.AddDbContext<OdeToFoodDbContext>(options => options.UseSqlServer(connection));

            //services.AddDbContext<OdeToFoodDbContext>(options => options.UseSqlServer(Configuration["database:connection"]));           
            
            services.AddIdentity<User, IdentityRole>()
                    .AddEntityFrameworkStores<OdeToFoodDbContext>();

            services.AddSingleton(provider => Configuration);
            services.AddSingleton<IGreeter, Greeter>();
            services.AddScoped<IRestaurantData, SqlRestaurantData>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,  IGreeter greeter, IHostingEnvironment hostingEnvironment)
        {  
            if(_isDevelopment)
            {
                app.UseDeveloperExceptionPage();
            }
            
            // app.UseDefaultFiles();
            // app.UseStaticFiles();
            
            app.UseFileServer();

            app.UseNodeModules((HostingEnvironment)hostingEnvironment);

            app.UseIdentity();
            
            //app.UseMvcWithDefaultRoute();
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            
            app.UseRuntimeInfoPage("/info");
            
            app.Run(async (context) =>
            {             
                
                var greeting = greeter.GetGreeting();
                await context.Response.WriteAsync(greeting);
            });
        }
    }
}
