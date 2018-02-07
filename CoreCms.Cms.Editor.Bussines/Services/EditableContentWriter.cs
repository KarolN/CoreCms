using System;
using System.Collections.Generic;
using System.Linq;
using CoreCms.Cms.Core.Contract.Model.Content;
using CoreCms.Cms.Core.Contract.Services;
using CoreCms.Cms.Editor.Bussines.Contract.Model.EditiableContent;
using CoreCms.Cms.Editor.Bussines.Contract.Services;

namespace CoreCms.Cms.Editor.Bussines.Services
{
    public class EditableContentWriter : IEditableContentWriter
    {
        private readonly IContentLoader _contentLoader;
        private readonly IContentWriter _contentWriter;

        public EditableContentWriter(IContentLoader contentLoader, IContentWriter contentWriter)
        {
            _contentLoader = contentLoader;
            _contentWriter = contentWriter;
        }
        
        public EditableContent UpdateContent(EditableContent editableContent)
        {
            var content = _contentLoader.Load(editableContent.ContentReference);
            UpdateProperties(editableContent.Properties, content);
            _contentWriter.UpdateContent(content);
            return editableContent;
        }

        private void UpdateProperties(List<EditableProperty> properties, Content content)
        {
            var contentProps = content.GetType().GetProperties();

            foreach (var editableProperty in properties)
            {
                var contentProperty = contentProps.Single(x => x.Name == editableProperty.Name);
                if (contentProperty.CanWrite)
                {
                    contentProperty.SetValue(content, editableProperty.Value);
                }
            }
        }
    }
}