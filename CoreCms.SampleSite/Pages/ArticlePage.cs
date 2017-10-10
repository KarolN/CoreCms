using CoreCms.Cms.Modules.Images.Model;
using CoreCms.Cms.Modules.Pages.Model;

namespace CoreCms.SampleSite.Pages
{
    public class ArticlePage : Page
    {
        public string Title { get; set; }
        public ImageReference Image1 { get; set; }
        public PageReference Other { get; set; }
    }
}