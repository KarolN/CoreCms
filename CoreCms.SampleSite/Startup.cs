using System;
using System.Reflection;
using CoreCms.Cms.Core.Contract;
using CoreCms.Cms.Core.Contract.Services;
using CoreCms.Cms.Core.Infrastructure;
using CoreCms.Cms.Editor.WebApi.Controllers;
using CoreCms.Cms.Editor.WebApi.JsonConverters;
using CoreCms.Cms.Editor.WebApi.ModelBinders;
using CoreCms.Cms.Modules.Images;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StructureMap;

namespace CoreCms.SampleSite
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var container = new Container();
            // Add framework services.
            services.AddCors(options => options.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            }));
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ContentModelBindFilter));
                options.ModelBinderProviders.Insert(0, new ContentReferenceModelBinderProvider());
            }).AddJsonOptions(options =>
                {
                    options.SerializerSettings.Converters.Add(new ContentReferenceJsonConverter(container));
                    options.SerializerSettings.Converters.Add(new EditablePropertyJsonConverter());
                })
                .AddApplicationPart(typeof(ContentTypesController).GetTypeInfo().Assembly);

          
            container.Configure(cfg =>
            {
                cfg.For<IConfigurationRoot>().Use(Configuration);
                cfg.Scan(x =>
                {
                    x.AssembliesAndExecutablesFromApplicationBaseDirectory();
                    x.LookForRegistries();
                });
                
                cfg.Populate(services);
            });

            return container.GetInstance<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {;
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseCors("CorsPolicy");
            app.UseStaticFiles();

            var router = app.ApplicationServices.GetService<ICmsRouter>();

            app.UseMvc(routes =>
            {
                routes.Routes.Add(router);
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}