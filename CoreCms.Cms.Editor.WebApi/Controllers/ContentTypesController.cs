using CoreCms.Cms.Editor.Bussines.Contract.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CoreCms.Cms.Editor.WebApi.Controllers
{
    [EnableCors("CorsPolicy")]
    public class ContentTypesController : Controller
    {
        private readonly IContentTreeService _contentTreeService;

        public ContentTypesController(IContentTreeService contentTreeService)
        {
            _contentTreeService = contentTreeService;
        }
        
        [Route("corecms/api/contentTypes")]
        [HttpGet]
        public IActionResult GetContentTypes()
        {
            return Ok(_contentTreeService.GetContentTypes());
        }
    }
}