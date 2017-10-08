using System.Collections.Generic;
using System.Linq;
using CoreCms.Cms.Core.Contract;
using CoreCms.Cms.Core.Contract.Model.Infractructure;
using CoreCms.Cms.Core.Contract.Services;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace CoreCms.Cms.Core.Infrastructure
{
    public class CmsViewComponentsDescriptorsProvider : ICmsViewComponentsDescriptorsProvider
    {
        private readonly IViewComponentDescriptorCollectionProvider _mvcViewComponentDescriptorCollectionProvider;

        public CmsViewComponentsDescriptorsProvider(IViewComponentDescriptorCollectionProvider mvcViewComponentDescriptorCollectionProvider)
        {
            _mvcViewComponentDescriptorCollectionProvider = mvcViewComponentDescriptorCollectionProvider;
        }
        
        public List<CmsViewComponentDescriptor> GetViewComponentDescriptors()
        {
            var mvcDescriptors = _mvcViewComponentDescriptorCollectionProvider.ViewComponents.Items;
            var cmsDescriptors = new List<CmsViewComponentDescriptor>();
            foreach (var mvcDescriptor in mvcDescriptors)
            {
                var typeInfo = mvcDescriptor.TypeInfo;
                var modelType = typeInfo.BaseType.GenericTypeArguments.FirstOrDefault();
                if (modelType != null)
                {
                    cmsDescriptors.Add(new CmsViewComponentDescriptor
                    {
                        ViewComponentType = mvcDescriptor.TypeInfo.GetType(),
                        ViewComponentName = mvcDescriptor.ShortName,
                        ModelType = modelType
                    });
                }
            }
            return cmsDescriptors;
        }
    }
}