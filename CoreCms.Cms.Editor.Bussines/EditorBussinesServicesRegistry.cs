using CoreCms.Cms.Editor.Bussines.Contract.Services;
using CoreCms.Cms.Editor.Bussines.Services;
using StructureMap;

namespace CoreCms.Cms.Editor.Bussines
{
    public class EditorBussinesServicesRegistry : Registry
    {
        public EditorBussinesServicesRegistry()
        {
            For<IContentTreeService>().Use<ContentTreeService>();
            For<IEditableContentGenerator>().Use<EditableContentGenerator>();
            For<IPropertyEditorRegistry>().Use<PropertyEditorRegistry>().Singleton();
            For<IEditableContentWriter>().Use<EditableContentWriter>();
        }
    }
}