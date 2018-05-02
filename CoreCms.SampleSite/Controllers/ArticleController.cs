using System;
using System.Collections.Generic;
using CoreCms.Cms.Core.Abstract;
using CoreCms.Cms.Core.Contract.Model.Content;
using CoreCms.Cms.Core.Contract.Services;
using CoreCms.SampleSite.Pages;
using Microsoft.AspNetCore.Mvc;

namespace CoreCms.SampleSite.Controllers
{
    public class ArticleController : CmsController<ArticlePage>
    {
        private readonly IContentLoader _contentLoader;

        public ArticleController(IContentLoader contentLoader)
        {
            _contentLoader = contentLoader;
        }
        
        public override IActionResult Index(ArticlePage contentModel)
        {
            var vm = new ArticlePageViewModel
            {
                ArticlePage = contentModel,
                ChildPages = _contentLoader.LoadChildren(contentModel.GetReference())
            };
            return View(vm);
        }
    }

    public class ArticlePageViewModel
    {
        public ArticlePage ArticlePage { get; set; }
        public List<ContentReference> ChildPages { get; set; }
    }
}