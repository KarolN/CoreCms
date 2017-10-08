using CoreCms.Cms.Core.Contract;
using CoreCms.Cms.Core.Contract.Services;

namespace CoreCms.Cms.Modules.Images.Services
{
    public abstract class ImagesModuleServiceBase : ICmsModuleService
    {
        public string GetContentTypeName()
        {
            return ImagesModuleConstants.ContentType;
        }
    }
}