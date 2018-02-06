using System.Collections.Generic;
using CoreCms.Cms.Core.Contract.Model.Content;
using CoreCms.Cms.Core.Contract.Services;
using CoreCms.Cms.Editor.Bussines.Contract.Model.EditiableContent;
using CoreCms.Cms.Editor.Bussines.Contract.Services;

namespace CoreCms.Cms.Editor.Bussines.Services
{
    public class EditableContentGenerator : IEditableContentGenerator
    {
        private readonly IContentLoader _contentLoader;

        public EditableContentGenerator(IContentLoader contentLoader)
        {
            _contentLoader = contentLoader;
        }
        
        public EditableContent GetEditable(ContentReference contentReference)
        {
            var content = _contentLoader.Load(contentReference);
            var editableContent = new EditableContent(content);
            editableContent.Properties = GetEditableProperties(content);

            return editableContent;
        }

        private List<EditableProperty> GetEditableProperties(Content content)
        {
            var properties = content.GetType().GetProperties();
            var editableProps = new List<EditableProperty>();

            foreach (var propertyInfo in properties)
            {
                var editableProperty = new EditableProperty();
                editableProperty.Name = propertyInfo.Name;
                editableProperty.Type = propertyInfo.PropertyType.Name;
                editableProperty.Value = propertyInfo.GetValue(content);
                editableProps.Add(editableProperty);
            }

            return editableProps;
        }
    }
}