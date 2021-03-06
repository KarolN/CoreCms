﻿using System;
using CoreCms.Cms.Core.Contract;
using CoreCms.Cms.Core.Contract.Services;
using CoreCms.Cms.Editor.Bussines.Contract.Services.ModuleSpecific;
using CoreCms.Cms.Modules.Pages.DataAccess;
using CoreCms.Cms.Modules.Pages.Services;
using StructureMap;

namespace CoreCms.Cms.Modules.Pages
{
    public class PageModuleServicesRegistry : Registry
    {
        public PageModuleServicesRegistry()
        {
            For<IContentReferenceLocator>().Use<PageReferenceLocator>().Named(PageConstants.ContentType).Singleton();
            For<IPageTreeRepository>().Use<PageTreeRepository>();
            For<ICmsModuleDescriptor>().Use<PageModuleDescriptor>().Named(PageConstants.ContentType);
            For<IControllerActionResolver>().Use<PageActionResolver>().Named(PageConstants.ContentType);
            For<IPageRepository>().Use<PageRepository>();
            For<IContentProvider>().Use<PageContentProvider>().Named(PageConstants.ContentType);
            For<IContentUrlProvider>().Use<PageUrlProvider>().Named(PageConstants.ContentType);
            For<IContentTreeProvider>().Use<PageTreeProvider>().Named(PageConstants.ContentType);
            For<IContentTemplateProvider>().Use<PageTemplatesProvider>().Named(PageConstants.ContentType);
        }
    }
} 
