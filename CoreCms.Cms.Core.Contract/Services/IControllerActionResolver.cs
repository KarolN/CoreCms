using CoreCms.Cms.Core.Contract.Model.Content;
using CoreCms.Cms.Core.Contract.Model.Infractructure;

namespace CoreCms.Cms.Core.Contract.Services
{
    public interface IControllerActionResolver : ICmsModuleService
    {
        CmsControllerActionDescriptor ResolveControllerAction(ContentReference contentReference);
    }
}