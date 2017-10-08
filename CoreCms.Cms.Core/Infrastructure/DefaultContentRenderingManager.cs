using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoreCms.Cms.Core.Contract;
using CoreCms.Cms.Core.Contract.Model.Content;
using CoreCms.Cms.Core.Contract.Services;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace CoreCms.Cms.Core.Infrastructure
{
    public class DefaultContentRenderingManager : IRenderingManager
    {
        private readonly Dictionary<Type, IContentRenderer> _renderersDictionary;
        
        public DefaultContentRenderingManager(List<IContentRenderer> contentRenderers)
        {
            _renderersDictionary = new Dictionary<Type, IContentRenderer>();
            foreach (var contentRenderer in contentRenderers)
            {
                _renderersDictionary.Add(contentRenderer.SupportedType, contentRenderer);
            }
        }

        public async Task<IHtmlContent> Render<T>(IHtmlHelper helper, T content, Func<T, object> renderProperty) where T : Content
        {
            var property = renderProperty(content);
            if (property == null)
            {
                return new HtmlString("");
            }
            var propertyType = property.GetType();
            if (_renderersDictionary.ContainsKey(propertyType))
            {
                var renderer = _renderersDictionary[propertyType];
                return await renderer.Render(content, renderProperty, helper);
            }

            foreach (var contentRenderer in _renderersDictionary)
            {
                if (contentRenderer.Value.CanRender(content, renderProperty))
                {
                    return await contentRenderer.Value.Render(content, renderProperty, helper);
                }
            }
            
            throw new ArgumentException("Cannot find renderer for property of type: " + propertyType.Name);
        }
    }
}