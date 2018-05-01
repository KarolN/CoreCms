using System.Collections.Generic;
using System.Reflection;
using CoreCms.Cms.Core.Contract.Model.Content;
using CoreCms.Cms.Core.Contract.Services;
using CoreCms.Common.Utils.Helpers;

namespace CoreCms.Cms.Core.Abstract
{
    public abstract class GenericContentTemplateProvider<TBaseContentType> :IContentTemplateProvider where TBaseContentType : Content
    {
        public abstract string GetContentTypeName();

        public List<ContentTemplate> GetContentTemplates()
        {
            var inheritedTypes = ReflectionHelper.GetDeriveredTypesInAssembly(typeof(TBaseContentType));
            
            var contentTemplates = new List<ContentTemplate>();

            foreach (var type in inheritedTypes)
            {
                contentTemplates.Add(new ContentTemplate
                {
                    Name = type.Name,
                    TemplateTypeFullName = type.AssemblyQualifiedName,
                    ContentType = GetContentTypeName()
                });
            }
            
            return contentTemplates;
        }
    }
}