using System.Collections.Generic;
using System.Linq;
using CoreCms.Cms.Core.Contract;
using CoreCms.Cms.Core.Contract.Model.Infractructure;
using CoreCms.Cms.Core.Contract.Services;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CoreCms.Cms.Core.Infrastructure
{
    public class CmsControllerActionDescriptorsProvider : ICmsControllerActionDescriptorsProvider
    {
        private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;

        public CmsControllerActionDescriptorsProvider(IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
        {
            _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
        }
        
        public IList<CmsControllerActionDescriptor> GetDescriptors()
        {
            var descriptors = new List<CmsControllerActionDescriptor>();

            foreach (var actionDescriptorsItem in _actionDescriptorCollectionProvider.ActionDescriptors.Items)
            {
                var controllerActionDescriptor = actionDescriptorsItem as ControllerActionDescriptor;
                if (controllerActionDescriptor != null && controllerActionDescriptor.ActionName == "Index")
                {
                    var controllerType = controllerActionDescriptor.ControllerTypeInfo;
                    var modelType = controllerType.BaseType.GenericTypeArguments.FirstOrDefault();
                    if (modelType != null)
                    {
                        descriptors.Add(new CmsControllerActionDescriptor
                        {
                            ControllerType = controllerType.AsType(),
                            ModelType = modelType,
                            ControllerName = controllerActionDescriptor.ControllerName
                        });
                    }
                }
            }
            return descriptors;
        }
    }
}