using System;
using System.Collections.Generic;

namespace TrueNewsFeeder.Models.NewsApi
{
    public class UniversalNewsEntity
    {
        public string Title { get; set; }
        public string Details { get; set; }
        public string UrlToImage { get; set; }
        public string Content { get; set; }
        public List<string> Urls { get; set; }
        public DateTime PublishAtStart { get; set; }
        public DateTime PublishAtEnd { get; set; }
    }
}