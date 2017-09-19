using CoreCms.Cms.Model.Content;

namespace CoreCms.Cms.Core.Contract
{
    public interface IContentLoader
    {
        Content Load(ContentReference contentReference);
    }
}