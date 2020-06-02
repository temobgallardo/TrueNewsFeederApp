using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TrueNewsFeeder.Repositories.Services.Implemantation;
using TrueNewsFeeder.Shared;
using Xunit;

namespace TrueNewsFeeder.UnitTest.Repositories
{
    public class TheGuardianNewsFactoryServiceImpUnitTest
    {
        private readonly HttpClient _client = new HttpClient();

        public async Task<byte[]> GetNewsArticleAsync(string request)
        {
            var response = await _client.GetAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return default;
            }

            return await response.Content.ReadAsByteArrayAsync();
        }
        public async Task<Stream> GetNewsArticleStreamAsync(string request)
        {
            var response = await _client.GetAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return default;
            }

            return await response.Content.ReadAsStreamAsync();
        }
        [Fact]
        public async Task ShouldGetNewsArticleAsyncWithArg()
        {
            var requestPlaceHolder = AppSettingsManager.Settings["TheGuardianUriPlaceHolder"];
            var request = string.Format(requestPlaceHolder
                , AppSettingsManager.Settings["TheGuardianServiceUrl"]
                , AppSettingsManager.Settings["Language"]
                , AppSettingsManager.Settings["TheGuardianApiSecret"]);
            byte[] content = await GetNewsArticleAsync(request);
            Xunit.Assert.NotNull(content);
            Xunit.Assert.NotEmpty(content);
        }
        [Fact]
        public async Task ShouldGetNewsArticlesAsync()
        {
            var product = new TheGuardianNewsFactoryServiceImp();
            var result = await product.GetNewsArticlesAsync();
            Xunit.Assert.NotNull(result);
            Xunit.Assert.NotEmpty(result);
        }
        [Fact]
        public async Task ShouldGetNewsArticlesAsyncWithArg()
        {
            var product = new TheGuardianNewsFactoryServiceImp();

            var requestPlaceHolder = AppSettingsManager.Settings["TheGuardianUriPlaceHolder"];
            var request = string.Format(requestPlaceHolder
                , AppSettingsManager.Settings["TheGuardianServiceUrl"]
                , AppSettingsManager.Settings["Language"]
                , AppSettingsManager.Settings["TheGuardianApiSecret"]);

            var result = await product.GetNewsArticlesAsync(request);
            Xunit.Assert.NotNull(result);
            Xunit.Assert.NotEmpty(result);
        }
        [Fact]
        public async Task ShouldGetNewsJsonStringAsync()
        {
            var product = new TheGuardianNewsFactoryServiceImp();

            var requestPlaceHolder = AppSettingsManager.Settings["TheGuardianUriPlaceHolder"];
            var request = string.Format(requestPlaceHolder
                , AppSettingsManager.Settings["TheGuardianServiceUrl"]
                , AppSettingsManager.Settings["Language"]
                , AppSettingsManager.Settings["TheGuardianApiSecret"]);

            var result = await product.GetNewsJsonStringAsync(request);
            Xunit.Assert.NotNull(result);
        }
        [Fact]
        public async Task ShouldParseTNewsToEntities()
        {
            var product = new TheGuardianNewsFactoryServiceImp();

            var requestPlaceHolder = AppSettingsManager.Settings["TheGuardianUriPlaceHolder"];
            var request = string.Format(requestPlaceHolder
                , AppSettingsManager.Settings["TheGuardianServiceUrl"]
                , AppSettingsManager.Settings["Language"]
                , AppSettingsManager.Settings["TheGuardianApiSecret"]);
            var json = await product.GetNewsJsonStringAsync(request);
            var content = product.GetLocalNewsTypeData(json);
            var result = product.ParseTNewsToEntities(content);
            Xunit.Assert.NotNull(result);
            Xunit.Assert.NotEmpty(result);
        }
    }
}
