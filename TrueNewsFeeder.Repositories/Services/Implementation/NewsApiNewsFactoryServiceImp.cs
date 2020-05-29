using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using TrueNewsFeeder.Models.NewsApi;
using TrueNewsFeeder.Shared;

namespace TrueNewsFeeder.Repositories.Services.Implementation
{
    public class NewsApiNewsFactoryServiceImp : NewsBaseFactoryService
    {
        public override async Task<IList<UniversalNewsEntity>> GetNewsArticlesAsync()
        {
            var request = string.Format(AppSettingsManager.Settings["UriHolderBySources"]
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
                var sourcesRespond = await _httpClient.GetAsync(request);

                if (!sourcesRespond.IsSuccessStatusCode)
                {
                    return default;
                }

                var sourcesStream = await sourcesRespond.Content.ReadAsStreamAsync();
                var sources = await ParseSourcesStreamToEntitiesAsync(sourcesStream);
                foreach (var s in sources)
                {
                    var newsRequest = string.Format(newsRequestPlaceHolder, s);
                    var news = await GetNewsArticlesAsync(newsRequest);
                    allNews.AddRange(news);
                }

                return allNews;
            }
            catch (Exception e)
            {
            }

            return default;
        }

        public override async Task<IList<UniversalNewsEntity>> GetNewsArticlesAsync(string request)
        {
            try
            {
                var newsStream = await GetNewsArticlesStreamAsync(request);

                return await ParseNewsStreamToEntitiesAsync(newsStream);
            }
            catch (Exception e)
            {

            }

            return default;
        }

        public override async Task<Stream> GetNewsArticlesStreamAsync(string request)
        {
            var response = await _httpClient.GetAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return default;
            }

            return await response.Content.ReadAsStreamAsync();
        }

        public override UniversalNewsEntity ParseJsonElementToEntity(JsonElement jElement)
        {
            return new UniversalNewsEntity
            {
                Title = jElement.GetProperty("title").GetString(),
                Description = jElement.GetProperty("description").GetString(),
                UrlToImage = jElement.GetProperty("urlToImage").ToString(),
                Content = jElement.GetProperty("content").ToString(),
                Source = jElement.GetProperty("source").GetProperty("name").ToString(),
                Url = jElement.GetProperty("url").ToString(),
                PublishedAt = jElement.GetProperty("publishedAt").GetDateTime()
            };
        }

        public override async Task<IList<UniversalNewsEntity>> ParseNewsStreamToEntitiesAsync(Stream newsStream)
        {
            var universalNewsEntities = new List<UniversalNewsEntity>();
            /*From C# 8.0 and higher we can do in-line 'using' keyword**/
            using (var jsonDoc = await JsonDocument.ParseAsync(newsStream))
            {
                /*First, we get the root element from the JsonDocument**/
                JsonElement root = jsonDoc.RootElement;
                JsonElement results = root.GetProperty("articles");
                foreach (var r in results.EnumerateArray())
                {
                    universalNewsEntities.Add(ParseJsonElementToEntity(r));
                }
            }

            return universalNewsEntities;
        }

        public string ParseJsonElementToEntityLocal(JsonElement jElement)
        {
            return jElement.GetProperty("id").GetString();
        }

        public async Task<IList<string>> ParseSourcesStreamToEntitiesAsync(Stream newsStream)
        {
            var sources = new List<string>();
            /*From C# 8.0 and higher we can do in-line 'using' keyword**/
            using (var jsonDoc = await JsonDocument.ParseAsync(newsStream))
            {
                /*First, we get the root element from the JsonDocument**/
                JsonElement root = jsonDoc.RootElement;
                JsonElement results = root.GetProperty("sources");
                foreach (var r in results.EnumerateArray())
                {
                    sources.Add(ParseJsonElementToEntityLocal(r));
                }
            }

            return sources;
        }
    }
}
