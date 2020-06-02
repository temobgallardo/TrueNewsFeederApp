using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrueNewsFeeder.Models;
using TrueNewsFeeder.Models.Guardian;
using TrueNewsFeeder.Models.NewsApi;
using TrueNewsFeeder.Shared;

namespace TrueNewsFeeder.Repositories.Services.Implementation
{
    public class NewsApiNewsFactoryServiceImp : BaseNewsFactoryService<News>
    {
        private new readonly string tag = typeof(NewsApiNewsFactoryServiceImp).Name;

        public override async Task<IList<UniversalNewsEntity>> GetNewsArticlesAsync()
        {
            var sourceRequest = string.Format(AppSettingsManager.Settings["UriHolderBySources"]
                    , AppSettingsManager.Settings["Service"]
                    , AppSettingsManager.Settings["Language"]
                    , AppSettingsManager.Settings["AppSecret"]);

            var newsRequestPlaceHolder = string.Format(AppSettingsManager.Settings["UriHolderEverythingBySource"]
                    , AppSettingsManager.Settings["ServiceEverything"]
                    , "{0}"
                    , AppSettingsManager.Settings["AppSecret"]);

            var allNews = new List<UniversalNewsEntity>();

            try
            {
                var sources = await GetNewsSourcesAsync(sourceRequest);

                /*Retrieving the first item so we do not burn out the API call limit on our Development Key**/
#if DEBUG
                string firstSource = sources.Sources.FirstOrDefault().Id;
                var newsRequest = string.Format(newsRequestPlaceHolder, firstSource);
                var news = await GetNewsArticlesAsync(newsRequest);
                allNews.AddRange(news);
#else
                     foreach (var s in sources.Sources)
                {
                    var newsRequest = string.Format(newsRequestPlaceHolder, s.Id);
                    var news = await GetNewsArticlesAsync(newsRequest);
                    allNews.AddRange(news);
                }
#endif
                return allNews;
            }
            catch (Exception e)
            {
                throw new Exception(tag, e);
            }
        }

        private async Task<News> GetNewsSourcesAsync(string request)
        {
            try
            {
                var sources = await GetNewsJsonStringAsync(request);

                return JsonConvert.DeserializeObject<News>(sources);
            }
            catch (Exception e)
            {
                throw new Exception(tag, e);
            }
        }

        public override IList<UniversalNewsEntity> ParseTNewsToEntities(News news)
        {
            var uNewsEntity = news.Articles.Select(article => new UniversalNewsEntity { 
                Content = article.Content,
                Description = article.Description,
                PublishedAt = article.PublishedAt,
                Source = article.Source.Name,
                Title = article.Title,
                Url = article.Url,
                UrlToImage = article.UrlToImage
            });

            return uNewsEntity.ToList();
        }
    }
}
