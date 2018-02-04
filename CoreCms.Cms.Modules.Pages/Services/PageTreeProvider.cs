using System;
using System.Collections.Generic;
using System.Linq;
using CoreCms.Cms.Editor.Bussines.Contract.Model.ContentTree;
using CoreCms.Cms.Editor.Bussines.Contract.Services.ModuleSpecific;
using CoreCms.Cms.Editor.Bussines.Services.BaseServices;
using CoreCms.Cms.Modules.Pages.DataAccess;
using CoreCms.Cms.Modules.Pages.Model;

namespace CoreCms.Cms.Modules.Pages.Services
{
    public class PageTreeProvider : ContentTreeProviderBase<PageTreeNode,IPageTreeRepository>
    {

        public PageTreeProvider(IPageTreeRepository pageTreeRepository)
        {
            _reposistory = pageTreeRepository;
        }

        public override string GetContentTypeName()
        {
            return PageConstants.ContentType;
        }

        protected override ContentTreeItemDto ConvertNodeToTreeItem(PageTreeNode pageTreeNode)
        {
            return new ContentTreeItemDto{Id = pageTreeNode.Id, Name = pageTreeNode.Name, ContentReference = pageTreeNode.ToContentReference()};
        }
    }
}