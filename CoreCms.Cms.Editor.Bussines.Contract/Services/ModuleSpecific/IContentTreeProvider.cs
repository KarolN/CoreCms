using CoreCms.Cms.Core.Contract.Services;
using CoreCms.Cms.Editor.Bussines.Contract.Model.ContentTree;

namespace CoreCms.Cms.Editor.Bussines.Contract.Services.ModuleSpecific
{
    public interface IContentTreeProvider : ICmsModuleService
    {
        ContentTreeDto GetContentTreeDto();
    }
}