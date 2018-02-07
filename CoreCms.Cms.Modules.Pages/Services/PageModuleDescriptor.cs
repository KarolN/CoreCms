using System;
using CoreCms.Cms.Core.Contract;
using CoreCms.Cms.Core.Contract.Services;
using CoreCms.Cms.Core.RouterProvider;
using CoreCms.Cms.Editor.Bussines.Contract.Model.EditiableContent;
using CoreCms.Cms.Editor.Bussines.Contract.Services;
using CoreCms.Cms.Modules.Pages.Model;

namespace CoreCms.Cms.Modules.Pages.Services
{
    public class PageModuleDescriptor : ICmsModuleDescriptor
    {
        public PageModuleDescriptor(IPropertyEditorRegistry registry)
        {
            registry.RegisterEditor(new PropertyEditor{TypeName = nameof(PageReference), EditorComponentName = "content-reference-editor"});
        }
        
        public string GetModuleName()
        {
            return PageConstants.ContentType;
        }

        public string GetModuleDisplayName()
        {
            return "Pages";
        }

        public Type GetRoutingHandlerType()
        {
            return typeof(CmsDefaultRoutingHandler);
        }

        public Type GetContentReferenceType()
        {
            return typeof(PageReference);
        }
    }
}