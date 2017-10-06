using CoreCms.Cms.Model.Content;

namespace CoreCms.Cms.Modules.Images.Model
{
    public class Image : Content
    {
        public string ImageType { get; set; }
        public string PhysicalPath { get; set; }
    }
}