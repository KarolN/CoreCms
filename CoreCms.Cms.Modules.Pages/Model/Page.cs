using CoreCms.Cms.Model.Content;

namespace CoreCms.Cms.Modules.Pages.Model
{
    public class Page : Content
    {
        public override ContentReference GetReference()
        {
            return new PageReference{Name = Name, PageId = Id, PageType = this.GetType().Name};
        }
    }
}