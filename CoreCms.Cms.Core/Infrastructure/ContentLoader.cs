using System.Collections.Generic;
using System.Linq;
using CoreCms.Cms.Core.Contract;
using CoreCms.Cms.Core.Contract.Model.Content;
using CoreCms.Cms.Core.Contract.Services;

namespace CoreCms.Cms.Core.Infrastructure
{
    public class ContentLoader : IContentLoader
    {
        private readonly List<IContentProvider> _contentProviders;

        public ContentLoader(List<IContentProvider> contentProviders)
        {
            _contentProviders = contentProviders;
        }
        
        public Content Load(ContentReference contentReference)
        {
            var provider = _contentProviders.Single(x => x.GetContentTypeName() == contentReference.ContentType);
            return provider.GetContent(contentReference);
        }

        public List<ContentReference> LoadChildren(ContentReference parentReference)
        {
            var provider = _contentProviders.Single(x => x.GetContentTypeName() == parentReference.ContentType);
            return provider.GetChidren(parentReference);
        }
    }
}