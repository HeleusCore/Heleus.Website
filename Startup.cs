using System.IO;
using Heleus.Website.Downloads;
using Markdig;
using Markdig.Extensions.EmphasisExtras;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Westwind.AspNetCore.Markdown;

namespace Heleus.Website
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public readonly IConfiguration Configuration;
        public readonly IWebHostEnvironment Environment;
        public ILogger<Startup> Logger { get; private set; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllers();
            var builder = services.AddRazorPages();

            if(Environment.IsDevelopment())
                builder.AddRazorRuntimeCompilation();

            services.AddMarkdown(config =>
            {
                // Create custom MarkdigPipeline 
                config.ConfigureMarkdigPipeline = builder =>
                {
                    builder
                        .UseEmphasisExtras(EmphasisExtraOptions.Default)
                        .UseCustomContainers()
                        .UseGenericAttributes();
                };
            });
        }

        public void Configure(IApplicationBuilder app, IHostApplicationLifetime lifetime, ILogger<Startup> logger)
        {
            Logger = logger;

            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
                app.UseHsts();
            }

            lifetime.ApplicationStarted.Register(OnStarted);
            lifetime.ApplicationStopping.Register(OnStopping);

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseStatusCodePagesWithReExecute("/error/{0}");

            app.UseStaticFiles(new StaticFileOptions
            {
                ServeUnknownFileTypes = true,
                OnPrepareResponse = ctx =>
                {
                    if(ctx.File?.Name == "windows-app-web-link")
                    {
                        ctx.Context.Response.ContentType = "application/json";
                    }
                }
            });

            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        void OnStarted()
        {
            var downloadsPath = Configuration.GetValue<string>("downloadspath");
            if (!string.IsNullOrEmpty(downloadsPath))
            {
                var info = new DirectoryInfo(downloadsPath);
                if (info.Exists)
                {
                    Logger.LogInformation($"Downloads path set to {info.FullName}");
                    DownloadsScheduler.Start(info);
                }
                else
                    Logger.LogError($"Downloads path {info.FullName} not found");
            }
            else
                Logger.LogError("Downloads path not set");
        }

        void OnStopping()
        {
            DownloadsScheduler.Stop();
        }
    }
}
