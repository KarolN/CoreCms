using CoreCms.Cms.Core.Contract.Model.Content;

namespace CoreCms.Cms.Core.Contract.Services
{
    public interface IContentReferenceLocator : ICmsModuleService
    {
        ContentReference LocateFromUrl(string url);
    }
}