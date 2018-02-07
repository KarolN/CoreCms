using System.Linq;
using System.Security.Cryptography.X509Certificates;
using CoreCms.Cms.Core.Contract;
using CoreCms.Cms.Core.Contract.Model.Content;
using CoreCms.Cms.Core.Contract.Services;
using CoreCms.Cms.Modules.Images.Model;
using CoreCms.DataAccess.Contract;

namespace CoreCms.Cms.Modules.Images.Services
{
    public class ImageContentProvider : ImagesModuleServiceBase, IContentProvider
    {
        private readonly IRepository<Image> _imageRepository;

        public ImageContentProvider(IRepository<Image> imageRepository)
        {
            _imageRepository = imageRepository;
        }
        
        public Content GetContent(ContentReference contentReference)
        {
            var imageReference = contentReference as ImageReference;
            if (imageReference == null)
            {
                return null;
            }
            var image = _imageRepository.GetQueryable().SingleOrDefault(x => x.Id == imageReference.ContentId);
            return image;
        }

        public void UpdateContent(Content content)
        {
            
        }
    }
}