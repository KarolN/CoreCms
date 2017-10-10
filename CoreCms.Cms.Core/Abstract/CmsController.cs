using CoreCms.Cms.Core.Contract.Model.Content;
using Microsoft.AspNetCore.Mvc;

namespace CoreCms.Cms.Core.Abstract
{
    public abstract class CmsController<TModel> : Controller where TModel : Content
    {
        public abstract IActionResult Index(TModel contentModel);
    }
}