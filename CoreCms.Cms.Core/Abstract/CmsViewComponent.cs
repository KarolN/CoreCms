using System.Threading.Tasks;
using CoreCms.Cms.Core.Contract.Model.Content;
using Microsoft.AspNetCore.Mvc;

namespace CoreCms.Cms.Core.Abstract
{
    public abstract class CmsViewComponent<TModel> : ViewComponent where TModel: Content, INestableContent
    {
        public abstract Task<IViewComponentResult> InvokeAsync(TModel contentModel);
    }
}