using System;
using System.Collections.Generic;
using CoreCms.Cms.ContentTreeHandler;
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
            var tree = new DefaultHierarchicContentTreeHandler(repo);

            var page = tree.GetContentNodeForUrl("/ArticlePage1");
            
            Console.WriteLine("Hello World!");
        }
    }
}