﻿using System.Collections.Generic;
using System.Linq;
using CoreCms.Cms.Core.Contract;
using CoreCms.Cms.Model.Content;

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
    }
}