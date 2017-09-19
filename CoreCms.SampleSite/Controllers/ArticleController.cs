using CoreCms.Cms.Core.Contract;
using CoreCms.SampleSite.Pages;
using Microsoft.AspNetCore.Mvc;

namespace CoreCms.SampleSite.Controllers
{
    public class ArticleController : CmsController<ArticlePage>
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}