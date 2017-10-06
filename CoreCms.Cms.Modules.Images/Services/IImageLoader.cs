using System.IO;
using CoreCms.Cms.Modules.Images.Model;

namespace CoreCms.Cms.Modules.Images.Services
{
    public interface IImageLoader
    {
        Stream GetImageStream(Image image);
    }
}