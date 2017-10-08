using System;
using CoreCms.Cms.Core.Contract;
using CoreCms.Cms.Core.Contract.Services;
using CoreCms.Cms.Modules.Images.RoutingProvider;

namespace CoreCms.Cms.Modules.Images
{
    public class ImagesModuleDescriptor : ICmsModuleDescriptor
    {
        public string GetModuleName()
        {
            return ImagesModuleConstants.ContentType;
        }

        public Type GetRoutingHandlerType()
        {
            return typeof(CmsImageRoutingHandler);
        }
    }
}