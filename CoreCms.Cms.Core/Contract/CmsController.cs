using CoreCms.Cms.Core.Contract.Model.Content;
using Microsoft.AspNetCore.Mvc;

namespace CoreCms.Cms.Core.Contract
{
    public abstract class CmsController<TModel> : Controller where TModel : Content
    {
        public abstract IActionResult Index(TModel contentModel);
    }
}