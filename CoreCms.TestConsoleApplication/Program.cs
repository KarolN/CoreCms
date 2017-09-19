using System;
using System.Collections.Generic;
using CoreCms.Cms.Modules.Pages.Model;
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
            var repo = new MongoRepository<PageTreeNode>(db);
            var root = new PageTreeNode(){Name = "RootPage", PageType = "HomePage",Children = new List<PageTreeNode>
            {
                new PageTreeNode(){Name = "page1", PageType = "ArticlePage"},
                new PageTreeNode(){Name = "page2", PageType = "ArticlePage"}
            }};
            repo.Insert(root);
            
            Console.WriteLine("Hello World!");
        }
    }
}