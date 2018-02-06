using CoreCms.Cms.Core.Contract.Model.Content;

namespace CoreCms.Cms.Modules.Pages.Model
{
    public class Page : Content
    {
        public override ContentReference GetReference()
        {
            return new PageReference{Name = Name, ContentId = Id, PageType = this.GetType().Name};
        }
    }
}