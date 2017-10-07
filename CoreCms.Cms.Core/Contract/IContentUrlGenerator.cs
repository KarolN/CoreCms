using CoreCms.Cms.Model.Content;

namespace CoreCms.Cms.Core.Contract
{
    public interface IContentUrlGenerator
    {
        string GetUrl(ContentReference contentReference);
    }
}