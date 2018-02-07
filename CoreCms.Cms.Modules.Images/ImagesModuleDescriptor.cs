using System;
using CoreCms.Cms.Core.Contract;
using CoreCms.Cms.Core.Contract.Services;
using CoreCms.Cms.Editor.Bussines.Contract.Model.EditiableContent;
using CoreCms.Cms.Editor.Bussines.Contract.Services;
using CoreCms.Cms.Modules.Images.Model;
using CoreCms.Cms.Modules.Images.RoutingProvider;

namespace CoreCms.Cms.Modules.Images
{
    public class ImagesModuleDescriptor : ICmsModuleDescriptor
    {
        public ImagesModuleDescriptor(IPropertyEditorRegistry registry)
        {
            registry.RegisterEditor(new PropertyEditor{TypeName = nameof(ImageReference), EditorComponentName = "content-reference-editor"});
        }
        
        public string GetModuleName()
        {
            return ImagesModuleConstants.ContentType;
        }

        public string GetModuleDisplayName()
        {
            return "Images";
        }

        public Type GetRoutingHandlerType()
        {
            return typeof(CmsImageRoutingHandler);
        }

        public Type GetContentReferenceType()
        {
            return typeof(ImageReference);
        }
    }
}