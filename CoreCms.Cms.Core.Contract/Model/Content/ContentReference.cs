namespace CoreCms.Cms.Core.Contract.Model.Content
{
    public abstract class ContentReference
    {
        public abstract string ContentType { get; }

        public string Name { get; set; }
    }
}