using System.Collections.Generic;
using CoreCms.Cms.Editor.Bussines.Contract.Model.EditiableContent;

namespace CoreCms.Cms.Editor.Bussines.Contract.Services
{
    public interface IPropertyEditorRegistry
    {
        List<PropertyEditor> GetPropertyEditors();

        void RegisterEditor(PropertyEditor editor);
    }
}