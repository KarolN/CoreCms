using CoreCms.Cms.Model.Content;
using Microsoft.AspNetCore.Mvc;

namespace CoreCms.Cms.Core.Contract
{
    public class CmsController<TModel> : Controller where TModel : Content
    {
        
    }
}