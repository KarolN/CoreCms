using System;
using System.Collections.Generic;
using CoreCms.Cms.Modules.Images.Model;
using CoreCms.Cms.Modules.Pages.Model;
using CoreCms.DataAccess.Base;
using CoreCms.SampleSite.Pages;
using MongoDB.Driver;

namespace CoreCms.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("test");
            var repo = new MongoRepository<ImagesTreeNode>(db);
            var node = new ImagesDirectory {Name = "", Id = Guid.Empty};
            repo.Insert(node);
            node = new ImagesDirectory(){Name="main", Id = Guid.NewGuid(), ParentId = node.Id};
            repo.Insert(node);
            var img = new ImageNode(){ImageId = Guid.Parse("8edd1f30-87ef-e049-8e71-4c96d1217635"), Id = Guid.NewGuid(), Name = "img", ParentId = node.Id};
            repo.Insert(img);
        }
    }
}