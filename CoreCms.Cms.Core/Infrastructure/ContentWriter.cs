using System.Collections.Generic;
using System.Linq;
using CoreCms.Cms.Core.Contract.Model.Content;
using CoreCms.Cms.Core.Contract.Services;

namespace CoreCms.Cms.Core.Infrastructure
{
    public class ContentWriter : IContentWriter
    {
        private readonly List<IContentProvider> _contentProviders;

        public ContentWriter(List<IContentProvider> contentProviders)
        {
            _contentProviders = contentProviders;
        }
        
        public void UpdateContent(Content content)
        {
            var contentReference = content.GetReference();
            var contentProvider = _contentProviders.Single(x => x.GetContentTypeName() == contentReference.ContentType);
            contentProvider.UpdateContent(content);
        }
    }
}