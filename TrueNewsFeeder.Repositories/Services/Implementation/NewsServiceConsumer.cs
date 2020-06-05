using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TrueNewsFeeder.Models.NewsApi;
using TrueNewsFeeder.Repositories.Services.Interfaces;
using TrueNewsFeeder.Shared;

namespace TrueNewsFeeder.Repositories.Services.Implemantation
{
    public class NewsServiceConsumer : IUniversalNewsRepository, IService
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        /**
         * TODO: Make this implementation or the Interface more clear, there is no way to tell what you are getting from the implementation until you used it which can be DANGEROUS as @Jair Palma mentioned.
         */
        public async Task<T> GetData<T>() where T : class, new()
        {
            try
            {
                var uriConstructed = String.Format(
                    AppSettingsManager.Settings["UriHolderEverythingAndDomain"]
                    , AppSettingsManager.Settings["ServiceEverything"]
                    , AppSettingsManager.Settings["Domains"]
                    , AppSettingsManager.Settings["AppSecret"]);
                var uri = new Uri(uriConstructed);
                var response = await _httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(json);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return default;
        }

        public async Task<T> GetData<T>(string url) where T : class, new()
        {
            try
            {
                var uri = new Uri(url);
                var response = await _httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(json);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return default;
        }

        public async Task<IList<Article>> GetNewsArticles()
        {
            try
            {
                var sourceRequest = string.Format(AppSettingsManager.Settings["UriHolderBySources"]
                    , AppSettingsManager.Settings["Service"]
                    , AppSettingsManager.Settings["Language"]
                    , AppSettingsManager.Settings["AppSecret"]);
                var sources = await GetNewsSources(sourceRequest);

                if (sources.Sources == null)
                {
                    return default;
                }

                var newsRequestPlaceHolder = string.Format(AppSettingsManager.Settings["UriHolderEverythingBySource"]
                    , AppSettingsManager.Settings["ServiceEverything"]
                    , "{0}"
                    , AppSettingsManager.Settings["AppSecret"]);

                var articles = new List<Article>();

                foreach (var source in sources.Sources)
                {
                    var newsRequest = string.Format(newsRequestPlaceHolder, source.Id);
                    var currentNews = await GetNews(newsRequest);
                    articles.AddRange(currentNews.Articles);
                }

                return articles;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return default;
        }

        public async Task<IList<Article>> GetNewsArticles(string sourcesRequest)
        {
            try
            {
                var sources = await GetNewsSources(sourcesRequest);

                if (sources == null)
                {
                    return default;
                }

                var articlesRequestPlaceHolder = string.Format(
                    AppSettingsManager.Settings["UriHolderEverythingBySource"]
                    , AppSettingsManager.Settings["ServiceEverything"]
                    , "{0}"
                    , AppSettingsManager.Settings["AppSecret"]);

                var articles = new List<Article>();
                var maxToNotBreakThe500RequestThreeshold = sources.Sources.Take(2);
                foreach (var source in maxToNotBreakThe500RequestThreeshold)
                {
                    var articleRequest = string.Format(articlesRequestPlaceHolder, source.Id);
                    var news = await GetNews(articleRequest);
                    if (news == null || news.Articles == null)
                    {
                        return default;
                    }

                    articles.AddRange(news.Articles);
                }

                return articles;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return default;
        }

        public async Task<News> GetNews(string request)
        {
            try
            {
                var response = await _httpClient.GetAsync(new Uri(request));
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<News>(json);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return default;
        }

        public async Task<News> GetNewsSources()
        {
            try
            {
                var uriConstructed = String.Format(
                    AppSettingsManager.Settings["UriHolderBySources"]
                    , AppSettingsManager.Settings["Service"]
                    , AppSettingsManager.Settings["Language"]
                    , AppSettingsManager.Settings["AppSecret"]);
                var uri = new Uri(uriConstructed);
                var response = await _httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<News>(json);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return default;
        }

        public async Task<News> GetNewsSources(string request)
        {
            try
            {
                var response = await _httpClient.GetAsync(new Uri(request));
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<News>(json);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return default;
        }
    }
}
