using CoreCms.Cms.Model.Content;

namespace CoreCms.Cms.Core.Contract
{
    public interface IContentReferenceLocator
    {
        ContentReference LocateFromUrl(string url);
    }
}