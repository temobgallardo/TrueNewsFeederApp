using System.Collections.Generic;

namespace TrueNewsFeeder.Models.NewsApi
{
    public class News
    {
        public string Status { get; set; }
        public int TotalResults { get; set; }
        public IList<Article> Articles { get; set; }
    }
}