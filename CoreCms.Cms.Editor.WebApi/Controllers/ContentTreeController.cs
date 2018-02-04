using CoreCms.Cms.Editor.Bussines.Contract.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CoreCms.Cms.Editor.WebApi.Controllers
{
    [EnableCors("CorsPolicy")]
    public class ContentTreeController : Controller
    {
        private readonly IContentTreeService _contentTreeService;

        public ContentTreeController(IContentTreeService contentTreeService)
        {
            _contentTreeService = contentTreeService;
        }

        [Route("corecms/api/contentTree")]
        [HttpGet]
        public IActionResult GetContentTree(string contentType)
        {
            var contentTree = _contentTreeService.GetContentTree(contentType);
            if (contentTree != null)
            {
                return Ok(contentTree);
            }
            return NotFound();
        }
    }
}