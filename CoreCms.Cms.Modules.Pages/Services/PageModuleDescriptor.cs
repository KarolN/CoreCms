using CoreCms.Cms.Core.Contract;

namespace CoreCms.Cms.Modules.Pages.Services
{
    public class PageModuleDescriptor : ICmsModuleDescriptor
    {
        public string GetModuleName()
        {
            return PageConstants.ContentType;
        }
    }
}