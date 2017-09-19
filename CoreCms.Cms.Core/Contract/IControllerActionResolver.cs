using CoreCms.Cms.Core.Infrastructure;
using CoreCms.Cms.Model.Content;

namespace CoreCms.Cms.Core.Contract
{
    public interface IControllerActionResolver : ICmsModuleService
    {
        CmsControllerActionDescriptor ResolveControllerAction(ContentReference contentReference);
    }
}