using System;
using System.Collections.Generic;
using CoreCms.Cms.Model.Content.ContentTree;
using CoreCms.DataAccess.Base;
using MongoDB.Driver;

namespace CoreCms.TestConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("test");
            var repo = new MongoRepository<ContentNode>(db);
            var content = new PageContentNode
            {
                ContentProvider = "PageContentProvider",
                Name = "StartPage",
                PageName = "Home page",
                ContentType = "Page",
                ChildNodes = new List<ContentNode>
                {
                    new PageContentNode
                    {
                        Id = Guid.NewGuid(),
                        ContentProvider = "PageContentProvider",
                        Name = "ArticlePage",
                        PageName = "Article1 page",
                        ContentType = "Page",
                    },
                    new PageContentNode
                    {
                        Id = Guid.NewGuid(),
                        ContentProvider = "PageContentProvider",
                        Name = "ArticlePage",
                        PageName = "Article2 page",
                        ContentType = "Page",
                    }
                }
            };
            repo.Insert(content);
            
            Console.WriteLine("Hello World!");
        }
    }
}