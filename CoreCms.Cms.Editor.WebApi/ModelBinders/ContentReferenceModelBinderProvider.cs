using CoreCms.Cms.Core.Contract.Model.Content;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace CoreCms.Cms.Editor.WebApi.ModelBinders
{
    public class ContentReferenceModelBinderProvider : IModelBinderProvider
    {   
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            return context.Metadata.ModelType is ContentReference ? new BinderTypeModelBinder(typeof(ContentReferenceModelBinder)) : null;
        }
    }
}