using System;
using System.IO;
using CoreCms.Cms.Modules.Images.Model;
using Microsoft.Extensions.Configuration;

namespace CoreCms.Cms.Modules.Images.Services
{
    public class FileSystemImageLoader : IImageLoader
    {
        private readonly IConfigurationRoot _configuration;

        public FileSystemImageLoader(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }
        
        public Stream GetImageStream(Image image)
        {
            var imagesDirectory = _configuration["CoreCms:Modules:Images:FileSystemProvider:ImagesDirectory"];
            if (imagesDirectory == null)
            {
                throw new Exception("Lack of congifuration of File system images provider");
            }

            var imagePath = Path.Combine(imagesDirectory, image.PhysicalPath);
            var file = File.Open(imagePath, FileMode.Open);
            return file;
        }
    }
}