using CoreCms.Cms.Core.Contract;
using CoreCms.Cms.Core.Contract.Services;

namespace CoreCms.Cms.Modules.Pages.Services
{
    public abstract class BasePageService : ICmsModuleService
    {
        public string GetContentTypeName()
        {
            return PageConstants.ContentType;
        }
    }
}