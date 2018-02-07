using CoreCms.Cms.Editor.Bussines.Contract.Model.EditiableContent;

namespace CoreCms.Cms.Editor.Bussines.Contract.Services
{
    public interface IEditableContentWriter
    {
        EditableContent UpdateContent(EditableContent editableContent);
    }
}