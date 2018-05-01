using CoreCms.Cms.Core.Contract.Services;
using CoreCms.Cms.Editor.Bussines.Contract.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CoreCms.Cms.Editor.WebApi.Controllers
{
    [EnableCors("CorsPolicy")]
    public class ContentTemplatesController : Controller
    {
        private readonly IContentTreeService _contentTreeService;

        public ContentTemplatesController(IContentTreeService contentTreeService)
        {
            _contentTreeService = contentTreeService;
        }
        
        [HttpGet]
        [Route("corecms/api/contentTemplates")]
        public IActionResult GetContentTemplates([FromQuery] string contentType)
        {
            return Ok(_contentTreeService.GetContentTemplates(contentType));
        }
    }
}