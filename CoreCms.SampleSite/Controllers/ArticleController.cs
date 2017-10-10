using CoreCms.Cms.Core.Abstract;
using CoreCms.Cms.Core.Contract;
using CoreCms.SampleSite.Pages;
using Microsoft.AspNetCore.Mvc;

namespace CoreCms.SampleSite.Controllers
{
    public class ArticleController : CmsController<ArticlePage>
    {
        public override IActionResult Index(ArticlePage contentModel)
        {
            return View(contentModel);
        }
    }
}