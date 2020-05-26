using System.Threading.Tasks;
using TrueNewsFeeder.Models.NewsApi;
using TrueNewsFeeder.Repositories.Services.Implemantation;
using TrueNewsFeeder.Shared;
using Xunit;

namespace TrueNewsFeeder.UnitTest
{
    public class NewsServiceConsumerUnitTest
    {
        [Fact]
        public async Task ShouldGetDataOfTypeNewsMocked()
        {
            var service = new NewsServiceConsumerMock();
            var result = await service.GetData<News>();
            Assert.NotNull(result);
            Assert.NotEmpty(result.Articles);
        }

        [Fact]
        public async Task ShouldGetDataOfTypeNews()
        {
            var service = new NewsServiceConsumer();
            var result = await service.GetData<News>();
            Assert.NotNull(result);
            Assert.NotEmpty(result.Articles);
        }

        [Fact]
        public async Task ShouldGetEveryNewsByDomain()
        {
            var url = string.Format(
                AppSettingsManager.Settings["UriHolderEverythingAndDomain"]
                , AppSettingsManager.Settings["ServiceEverything"]
                , AppSettingsManager.Settings["Domains"]
                , AppSettingsManager.Settings["AppSecret"]);
            var service = new NewsServiceConsumer();
            var result = await service.GetData<News>(url);
            Assert.NotNull(result);
            Assert.NotEmpty(result.Articles);
        }

        [Fact]
        public async Task ShouldGetNewsArticles()
        {
            var service = new NewsServiceConsumer();
            var result = await service.GetNewsArticles();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task ShouldGetNewsArticleWithParameter()
        {
            var request = string.Format(
                AppSettingsManager.Settings["UriHolderBySources"]
                , AppSettingsManager.Settings["Service"]
                , AppSettingsManager.Settings["Language"]
                , AppSettingsManager.Settings["AppSecret"]);
            var service = new NewsServiceConsumer();
            var result = await service.GetNewsArticles(request);
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task ShouldGetNews()
        {
            var request = string.Format(
                AppSettingsManager.Settings["UriHolderEverythingAndDomain"]
                , AppSettingsManager.Settings["ServiceEverything"]
                , AppSettingsManager.Settings["Domains"]
                , AppSettingsManager.Settings["AppSecret"]);
            var service = new NewsServiceConsumer();
            var result = await service.GetNews(request);
            Assert.NotNull(result);
            Assert.NotEmpty(result.Articles);
        }

        [Fact]
        public async Task ShouldGetNewsSources()
        {
            var service = new NewsServiceConsumer();
            var result = await service.GetNewsSources();
            Assert.NotNull(result);
            Assert.NotEmpty(result.Sources);
        }

        [Fact]
        public async Task ShouldGetNewsSourcesWithParameter()
        {
            var request = string.Format(
                AppSettingsManager.Settings["UriHolderBySources"]
                , AppSettingsManager.Settings["Service"]
                , AppSettingsManager.Settings["Language"]
                , AppSettingsManager.Settings["AppSecret"]);
            var service = new NewsServiceConsumer();
            var result = await service.GetNewsSources(request);
            Assert.NotNull(result);
            Assert.NotEmpty(result.Sources);
        }
    }
}
