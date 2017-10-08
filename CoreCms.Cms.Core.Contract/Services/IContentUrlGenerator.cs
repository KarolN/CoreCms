using CoreCms.Cms.Core.Contract.Model.Content;

namespace CoreCms.Cms.Core.Contract.Services
{
    public interface IContentUrlGenerator
    {
        string GetUrl(ContentReference contentReference);
    }
}