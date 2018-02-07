using System.Collections.Generic;
using CoreCms.Cms.Editor.Bussines.Contract.Model.EditiableContent;
using CoreCms.Cms.Editor.Bussines.Contract.Services;

namespace CoreCms.Cms.Editor.Bussines.Services
{
    public class PropertyEditorRegistry : IPropertyEditorRegistry
    {
        private List<PropertyEditor> _propertyEditors = new List<PropertyEditor>();

        public PropertyEditorRegistry()
        {
            _propertyEditors.Add(new PropertyEditor{TypeName = "String", EditorComponentName = "string-editor"});
        }
        
        public List<PropertyEditor> GetPropertyEditors()
        {
            return _propertyEditors;
        }

        public void RegisterEditor(PropertyEditor editor)
        {
            if (!_propertyEditors.Exists(x => x.TypeName == editor.TypeName))
            {
                _propertyEditors.Add(editor);
            }
        }
    }
}