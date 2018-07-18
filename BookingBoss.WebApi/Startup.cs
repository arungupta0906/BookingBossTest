using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingBoss.WebApi.DataContext;
using BookingBoss.WebApi.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BookingBoss.WebApi
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
            services.AddDbContext<WebApiContext>(opt =>
                opt.UseInMemoryDatabase("ProductList"));
            services.AddTransient<IProductService, ProductService>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            loggerFactory.AddFile("Logs/myapp-{Date}.txt");

            //loggerFactory.AddConsole(Configuration.GetSection("Logging")); 
            //loggerFactory.AddDebug(); 

            app.UseMvc();
        }
    }
}
