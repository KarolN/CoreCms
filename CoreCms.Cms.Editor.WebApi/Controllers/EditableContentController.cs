using CoreCms.Cms.Core.Contract.Model.Content;
using CoreCms.Cms.Editor.Bussines.Contract.Model.EditiableContent;
using CoreCms.Cms.Editor.Bussines.Contract.Services;
using CoreCms.Cms.Editor.WebApi.ModelBinders;
using Microsoft.AspNetCore.Mvc;

namespace CoreCms.Cms.Editor.WebApi.Controllers
{
    public class EditableContentController : Controller
    {
        private readonly IEditableContentGenerator _editableContentGenerator;
        private readonly IEditableContentWriter _editableContentWriter;

        public EditableContentController(IEditableContentGenerator editableContentGenerator, IEditableContentWriter editableContentWriter)
        {
            _editableContentGenerator = editableContentGenerator;
            _editableContentWriter = editableContentWriter;
        }
        
        [Route("corecms/api/editableContent")]
        [HttpGet]
        public IActionResult GetEditableContent([ModelBinder(typeof(ContentReferenceModelBinder))]ContentReference contentReference)
        {
            var editable = _editableContentGenerator.GetEditable(contentReference);
            return Ok(editable);
        }

        [Route("corecms/api/editableContent")]
        [HttpPut]
        public IActionResult SaveEditableContent([FromBody] EditableContent content)
        {
            var savedContent = _editableContentWriter.UpdateContent(content);
            return Ok(savedContent);
        }
    }
}