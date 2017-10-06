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
            var node = new ImagesDirectory{Name = "", Id = Guid.NewGuid(), Children = new List<ImagesTreeNode>
            {
                new ImagesDirectory()
                {
                    Name = "main",
                    Id = Guid.NewGuid(),
                    Children = new List<ImagesTreeNode>
                    {
                        new ImageNode
                        {
                            ImageId = Guid.NewGuid(),
                            Id = Guid.NewGuid(),
                            Name="img"
                        }
                    }
                }
            }};

            repo.Insert(node);
        }
    }
}