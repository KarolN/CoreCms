using CoreCms.Cms.Editor.Bussines.Contract.Model.EditiableContent;
using CoreCms.Cms.Editor.Bussines.Contract.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CoreCms.Cms.Editor.WebApi.Controllers
{
    [EnableCors("CorsPolicy")]
    public class ContentController : Controller
    {
        private readonly IEditableContentWriter _editableContentWriter;

        public ContentController(IEditableContentWriter editableContentWriter)
        {
            _editableContentWriter = editableContentWriter;
        }
        
        [Route("corecms/api/content")]
        [HttpPost]
        public IActionResult CreateContent([FromBody] NewContentDto newContentDto)
        {
            var reference = _editableContentWriter.CreateContent(newContentDto);
            return Ok(reference);
        }
    }
}