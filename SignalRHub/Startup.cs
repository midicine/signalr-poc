using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SignalRHub.Hubs;

namespace SignalRHub
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => 
                options.AddPolicy("CorsPolicy", builder 
                    => builder
                        .AllowAnyMethod().AllowAnyHeader()
                        .WithOrigins("http://localhost:11886")
                        .AllowCredentials()));

            services.AddSignalR();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");

            app.UseSignalR(routes =>
            {
                routes.MapHub<MessageHub>($"/{nameof(MessageHub)}");
            });
        }
    }
}
