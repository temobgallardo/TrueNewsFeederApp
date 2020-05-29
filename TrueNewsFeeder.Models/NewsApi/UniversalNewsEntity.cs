using System;

namespace TrueNewsFeeder.Models.NewsApi
{
    public class UniversalNewsEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string UrlToImage { get; set; }
        public string Content { get; set; }
        public string Source { get; set; }
        public string Url { get; set; }
        public DateTime PublishedAt { get; set; }
        public DateTime PublishedAtEnd { get; set; }
    }
}