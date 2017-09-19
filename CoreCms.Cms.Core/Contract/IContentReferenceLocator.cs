using CoreCms.Cms.Model.Content;

namespace CoreCms.Cms.Core.Contract
{
    public interface IContentReferenceLocator : ICmsModuleService
    {
        ContentReference LocateFromUrl(string url);
    }
}