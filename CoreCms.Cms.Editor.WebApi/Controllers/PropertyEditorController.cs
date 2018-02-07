using CoreCms.Cms.Editor.Bussines.Contract.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoreCms.Cms.Editor.WebApi.Controllers
{
    public class PropertyEditorController : Controller
    {
        private readonly IPropertyEditorRegistry _propertyEditorRegistry;

        public PropertyEditorController(IPropertyEditorRegistry propertyEditorRegistry)
        {
            _propertyEditorRegistry = propertyEditorRegistry;
        }
        
        [Route("corecms/api/propertyEditors")]
        [HttpGet]
        public IActionResult GetPropertyEditors()
        {
            return Ok(_propertyEditorRegistry.GetPropertyEditors());
        }
    }
}