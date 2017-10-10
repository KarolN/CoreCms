using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreCms.Cms.Core.Abstract;
using CoreCms.Cms.Core.Contract;
using CoreCms.SampleSite.Pages;
using Microsoft.AspNetCore.Mvc;

namespace CoreCms.SampleSite.Controllers
{
    public class HomeController : CmsController<HomePage>
    {
        public override IActionResult Index(HomePage contentModel)
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}