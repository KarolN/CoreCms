using System.Collections.Generic;
using System.Linq;
using CoreCms.Cms.Core.Contract;
using CoreCms.Cms.Model.Content;

namespace CoreCms.Cms.Core.Infrastructure
{
    public class CmsContentUrlGenerator : IContentUrlGenerator
    {
        private readonly Dictionary<string, IContentUrlProvider> _providers;
        public CmsContentUrlGenerator(List<IContentUrlProvider> urlProviders)
        {
            _providers =urlProviders.ToDictionary(x => x.GetContentTypeName(), x => x);
        }
        
        public string GetUrl(ContentReference contentReference)
        {
            return _providers[contentReference.ContentType].GetContentUrl(contentReference);
        }
    }
}