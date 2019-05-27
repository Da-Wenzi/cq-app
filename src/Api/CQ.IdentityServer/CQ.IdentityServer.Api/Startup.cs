using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace CQ.IdentityServer.Api
{
    public class Startup
    {


        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }

        public IHostingEnvironment Environment { get; private set; }


        public void ConfigureServices(IServiceCollection services)
        {
            string migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            IIdentityServerBuilder builder = services.AddIdentityServer()
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = contextBuilder => 
                        contextBuilder.UseSqlServer(Configuration.GetConnectionString("ConfigurationDbContext"), sql => sql.MigrationsAssembly(migrationsAssembly));
                })
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = contextBuilder =>
                        contextBuilder.UseSqlServer(Configuration.GetConnectionString("PersistedGrantDbContext"), sql => sql.MigrationsAssembly(migrationsAssembly));

                    options.EnableTokenCleanup = true;
                });

            if (Environment.IsDevelopment())
            {
                builder.AddDeveloperSigningCredential();
            }
            else
            {
                throw new Exception("need to configure key material");
            }

        }

        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseIdentityServer();
            app.UseHttpsRedirection();
        }
    }
}
