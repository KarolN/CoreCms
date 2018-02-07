using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreCms.Cms.Core.Contract.Model.Content;
using CoreCms.Cms.Core.Contract.Services;
using CoreCms.Common.Utils.Extensions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using StructureMap;

namespace CoreCms.Cms.Editor.WebApi.ModelBinders
{
    public class ContentReferenceModelBinder : IModelBinder
    {
        private Dictionary<string, Type> _contentReferenceTypesRegistry;
        
        public ContentReferenceModelBinder(List<ICmsModuleDescriptor> descriptors)
        {
            _contentReferenceTypesRegistry =
                descriptors.ToDictionary(x => x.GetModuleName(), x => x.GetContentReferenceType());
        }
        
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var contentType = bindingContext.ValueProvider.GetValue(nameof(ContentReference.ContentType));
            if (contentType.FirstValue == null || !_contentReferenceTypesRegistry.ContainsKey(contentType.FirstValue))
            {
                return Task.CompletedTask;
            }

            var referenceType = _contentReferenceTypesRegistry[contentType.FirstValue];
            var reference = Activator.CreateInstance(referenceType);
            foreach (var propertyInfo in referenceType.GetProperties())
            {
                var modelProperty = bindingContext.ValueProvider.GetValue(propertyInfo.Name.ToLowerCaseFirstLetter());
                if (modelProperty.FirstValue != null && propertyInfo.CanWrite)
                {
                    var type = propertyInfo.PropertyType;
                    var parseMethod = type.GetMethod("Parse");
                    if (parseMethod != null)
                    {
                        object parsed = parseMethod.Invoke(null, new object[] {modelProperty.FirstValue});
                        propertyInfo.SetValue(reference, parsed);
                    }
                    else
                    {
                        propertyInfo.SetValue(reference, Convert.ChangeType(modelProperty.FirstValue, type));
                    }
                }
            }
            bindingContext.Result = ModelBindingResult.Success(reference);
            return Task.CompletedTask;
        }
    }
}