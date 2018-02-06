using CoreCms.Cms.Core.Contract.Model.Content;
using CoreCms.Cms.Editor.Bussines.Contract.Model.EditiableContent;

namespace CoreCms.Cms.Editor.Bussines.Contract.Services
{
    public interface IEditableContentGenerator
    {
        EditableContent GetEditable(ContentReference contentReference);
    }
}