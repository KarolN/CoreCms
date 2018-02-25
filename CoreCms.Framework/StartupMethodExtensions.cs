using System;
using System.Reflection;
using CoreCms.Cms.Core.Contract.Services;
using CoreCms.Cms.Core.Infrastructure;
using CoreCms.Cms.Editor.WebApi.Controllers;
using CoreCms.Cms.Editor.WebApi.JsonConverters;
using CoreCms.Cms.Editor.WebApi.ModelBinders;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StructureMap;

namespace CoreCms.Framework
{
    public static class StartupMethodExtensions
    {
        public static IApplicationBuilder UseCoreCms(this IApplicationBuilder app, Action<IRouteBuilder> routesConfig)
        {
            app.UseCors("CorsPolicy");
            var router = app.ApplicationServices.GetService<ICmsRouter>();

            app.UseMvc(routes =>
            {
                routes.Routes.Add(router);
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
                routesConfig(routes);
            });
            return app;
        }

        public static IServiceProvider AddCoreCms(this IServiceCollection services, IConfigurationRoot configuration, 
            Action<MvcOptions> mvcOptions,
            Action<IMvcBuilder> mvcSettings,
            Action<ConfigurationExpression> containerConfig)
        {
            var container = new Container();
            // Add framework services.
            services.AddCors(options => options.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            }));
            var mvcBuilder = services.AddMvc(options =>
                {
                    options.Filters.Add(typeof(ContentModelBindFilter));
                    options.ModelBinderProviders.Insert(0, new ContentReferenceModelBinderProvider());
                    mvcOptions(options);
                }).AddJsonOptions(options =>
                {
                    options.SerializerSettings.Converters.Add(new ContentReferenceJsonConverter(container));
                    options.SerializerSettings.Converters.Add(new EditablePropertyJsonConverter());
                })
                .AddApplicationPart(typeof(ContentTypesController).GetTypeInfo().Assembly);
            mvcSettings(mvcBuilder);

          
            container.Configure(cfg =>
            {
                cfg.For<IConfigurationRoot>().Use(configuration);
                cfg.Scan(x =>
                {
                    x.AssembliesAndExecutablesFromApplicationBaseDirectory();
                    x.LookForRegistries();
                });
                
                cfg.Populate(services);
                containerConfig(cfg);
            });

            return container.GetInstance<IServiceProvider>();
        }
    }
}