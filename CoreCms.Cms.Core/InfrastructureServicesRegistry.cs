﻿using CoreCms.Cms.Core.Contract;
using CoreCms.Cms.Core.Contract.Services;
using CoreCms.Cms.Core.DefaultContentRenderers;
using CoreCms.Cms.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using StructureMap;

namespace CoreCms.Cms.Core
{
    public class InfrastructureServicesRegistry : Registry
    {
        public InfrastructureServicesRegistry()
        {
            For<ICmsControllerActionDescriptorsProvider>().Use<CmsControllerActionDescriptorsProvider>();
            For<ICmsViewComponentsDescriptorsProvider>().Use<CmsViewComponentsDescriptorsProvider>();
            For<IContentLoader>().Use<ContentLoader>();
            For<IContentWriter>().Use<ContentWriter>();
            For<IRenderingManager>().Singleton().Use<DefaultContentRenderingManager>();
            For<IContentUrlGenerator>().Singleton().Use<CmsContentUrlGenerator>();
            For<IContentTemplateLoader>().Singleton().Use<ContentTemplateLoader>();

            For<IContentRenderer>().Singleton().Use<IntegerContentRenerer>();
            For<IContentRenderer>().Singleton().Use<StringContentRenerer>();
            For<IContentRenderer>().Singleton().Use<NestableContentRenderer>();
        }
    }
}