using CoreCms.Cms.Core.Contract.Model.Content;
using CoreCms.Cms.Editor.Bussines.Contract.Services;
using CoreCms.Cms.Editor.WebApi.ModelBinders;
using Microsoft.AspNetCore.Mvc;

namespace CoreCms.Cms.Editor.WebApi.Controllers
{
    public class EditableContentController : Controller
    {
        private readonly IEditableContentGenerator _editableContentGenerator;

        public EditableContentController(IEditableContentGenerator editableContentGenerator)
        {
            _editableContentGenerator = editableContentGenerator;
        }
        
        [Route("corecms/api/editableContent")]
        [HttpGet]
        public IActionResult GetEditableContent([ModelBinder(typeof(ContentReferenceModelBinder))]ContentReference contentReference)
        {
            var editable = _editableContentGenerator.GetEditable(contentReference);
            return Ok(editable);
        }
    }
}