using System;
using System.Collections.Generic;
using CoreCms.Cms.Core.Contract;
using CoreCms.Cms.Model.Content;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace CoreCms.Cms.Core.Infrastructure
{
    public class DefaultContentRenderingManager : IRenderingManager
    {
        private readonly Dictionary<Type, IContentRenderer> renderersDictionary;
        
        public DefaultContentRenderingManager(List<IContentRenderer> contentRenderers)
        {
            renderersDictionary = new Dictionary<Type, IContentRenderer>();
            foreach (var contentRenderer in contentRenderers)
            {
                renderersDictionary.Add(contentRenderer.SupportedType, contentRenderer);
            }
        }

        public IHtmlContent Render<T>(IHtmlHelper helper, T content, Func<T, object> renderProperty) where T : Content
        {
            var propertyType = renderProperty(content).GetType();
            if (renderersDictionary.ContainsKey(propertyType))
            {
                var renderer = renderersDictionary[propertyType];
                return renderer.Render(content, renderProperty);
            }
            
            throw new ArgumentException("Cannot find renderer for property of type: " + propertyType.Name);
        }
    }
}