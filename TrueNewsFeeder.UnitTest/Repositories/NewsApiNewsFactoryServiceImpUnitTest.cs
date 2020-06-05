using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TrueNewsFeeder.Models.NewsApi;
using TrueNewsFeeder.Repositories.Services.Implementation;
using TrueNewsFeeder.Shared;
using Xunit;

namespace TrueNewsFeeder.UnitTest.Repositories
{
    public class NewsApiNewsFactoryServiceImpUnitTest
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private NewsApiNewsRepositoryFactoryImp _instance = new NewsApiNewsRepositoryFactoryImp();

        public async Task<string> GetNewsJsonStringAsync(string request)
        {
            var response = await _httpClient.GetAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return default;
            }

            return await response.Content.ReadAsStringAsync();
        }
        public async Task<News> GetNewsSourcesAsync(string request)
        {
            try
            {
                var sources = await GetNewsJsonStringAsync(request);

                return JsonConvert.DeserializeObject<News>(sources);
            }
            catch (Exception e)
            {
                throw new Exception("", e);
            }
        }

        [Fact]
        public async Task ShouldGetNewsArticlesAsync()
        {
            var result = await _instance.GetNewsArticlesAsync();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
        [Fact]
        public async Task ShouldGetNewsArticlesAsyncWithArg()
        {
            var request = string.Format(AppSettingsManager.Settings["UriHolderEverythingBySource"]
                    , AppSettingsManager.Settings["ServiceEverything"]
                    , "abc-news"
                    , AppSettingsManager.Settings["AppSecret"]);
            var result = await _instance.GetNewsArticlesAsync(request);
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
        [Fact]
        public async Task ShouldGetLocalNewsType()
        {
            var sourceRequest = string.Format(AppSettingsManager.Settings["UriHolderBySources"]
                    , AppSettingsManager.Settings["Service"]
                    , AppSettingsManager.Settings["Language"]
                    , AppSettingsManager.Settings["AppSecret"]);
            var jsonResponse = await _instance.GetNewsJsonStringAsync(sourceRequest);
            var result = _instance.GetLocalNewsTypeData(jsonResponse);
            Assert.NotNull(result);
        }
        [Fact]
        public async Task ShouldGetNewsJsonStringAsync()
        {
            var sourceRequest = string.Format(AppSettingsManager.Settings["UriHolderBySources"]
                    , AppSettingsManager.Settings["Service"]
                    , AppSettingsManager.Settings["Language"]
                    , AppSettingsManager.Settings["AppSecret"]);
            var result = await _instance.GetNewsJsonStringAsync(sourceRequest);
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
        [Fact]
        public async Task ShouldParseTNewsToEntities()
        {
            var sourceRequest = string.Format(AppSettingsManager.Settings["UriHolderBySources"]
                    , AppSettingsManager.Settings["Service"]
                    , AppSettingsManager.Settings["Language"]
                    , AppSettingsManager.Settings["AppSecret"]);
            var sources = await GetNewsSourcesAsync(sourceRequest);

            var newsRequestPlaceHolder = string.Format(AppSettingsManager.Settings["UriHolderEverythingBySource"]
                   , AppSettingsManager.Settings["ServiceEverything"]
                   , "{0}"
                   , AppSettingsManager.Settings["AppSecret"]);
            string firstSource = sources.Sources.FirstOrDefault().Id;
            var newsRequest = string.Format(newsRequestPlaceHolder, firstSource);
            var jsonResponse = await _instance.GetNewsJsonStringAsync(newsRequest);
            var news = _instance.GetLocalNewsTypeData(jsonResponse);
            var result = _instance.ParseTNewsToEntities(news);
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
