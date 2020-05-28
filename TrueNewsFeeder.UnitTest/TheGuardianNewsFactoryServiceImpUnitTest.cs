using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TrueNewsFeeder.Models.NewsApi;
using TrueNewsFeeder.Repositories.Services.Implemantation;
using TrueNewsFeeder.Shared;
using Xunit;

namespace TrueNewsFeeder.UnitTest
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
        public async Task ShouldGetNewsArticleAsync()
        {
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
        public async Task ShouldGetTheGuardianJsonProperties()
        {
            var requestPlaceHolder = AppSettingsManager.Settings["TheGuardianUriPlaceHolder"];
            var request = string.Format(requestPlaceHolder
                , AppSettingsManager.Settings["TheGuardianServiceUrl"]
                , AppSettingsManager.Settings["Language"]
                , AppSettingsManager.Settings["TheGuardianApiSecret"]);
            var content = await GetNewsArticleStreamAsync(request);

            /*From C# 8.0 and higher we can do in-line 'using' keyword**/
            using var jsonDoc = await JsonDocument.ParseAsync(content);
            var universalNewsEntities = new List<UniversalNewsEntity>();
            /*First, we get the root element from the JsonDocument**/
            JsonElement root = jsonDoc.RootElement;
            JsonElement results = root.GetProperty("response").GetProperty("results");
            foreach (var r in results.EnumerateArray())
            {
                r.TryGetProperty("webTitle", out JsonElement title);
                r.GetProperty("blocks").TryGetProperty("body", out JsonElement body);
                var contentBody = new JsonElement();
                /*using 'break' because it's assured that this always has one element**/
                foreach (var b in body.EnumerateArray())
                {
                    b.TryGetProperty("bodyTextSummary", out contentBody);
                    break;
                }

                r.GetProperty("fields").TryGetProperty("thumbnail", out JsonElement urlToImage);
                r.TryGetProperty("apiUrl", out JsonElement url);
                r.TryGetProperty("webPublicationDate", out JsonElement webPublicationDate);

                var news = new UniversalNewsEntity
                {
                    Title = title.GetString(),
                    Details = contentBody.ToString().Substring(0, 253) + "...",
                    UrlToImage = urlToImage.ToString(),
                    Content = contentBody.ToString(),
                    Source = "The Guardian",
                    Url = url.ToString(),
                    PublishAt = webPublicationDate.GetDateTime()
                };
                universalNewsEntities.Add(news);
            }

            Xunit.Assert.NotNull(universalNewsEntities);
            Xunit.Assert.NotEmpty(universalNewsEntities);
        }
        [Fact]
        public async Task ShouldGetTheGuardianJsonPropertiesShorter()
        {
            var requestPlaceHolder = AppSettingsManager.Settings["TheGuardianUriPlaceHolder"];
            var request = string.Format(requestPlaceHolder
                , AppSettingsManager.Settings["TheGuardianServiceUrl"]
                , AppSettingsManager.Settings["Language"]
                , AppSettingsManager.Settings["TheGuardianApiSecret"]);
            var content = await GetNewsArticleStreamAsync(request);

            /*From C# 8.0 and higher we can do in-line 'using' keyword**/
            using var jsonDoc = await JsonDocument.ParseAsync(content);
            var universalNewsEntities = new List<UniversalNewsEntity>();
            /*First, we get the root element from the JsonDocument**/
            JsonElement root = jsonDoc.RootElement;
            JsonElement results = root.GetProperty("response").GetProperty("results");
            foreach (var r in results.EnumerateArray())
            {
                r.GetProperty("blocks").TryGetProperty("body", out JsonElement body);
                var contentBody = body.EnumerateArray().FirstOrDefault().GetProperty("bodyTextSummary").GetString();

                var news = new UniversalNewsEntity
                {
                    Title = r.GetProperty("webTitle").GetString(),
                    Details = contentBody.ToString().Substring(0, 253) + "...",
                    UrlToImage = r.GetProperty("fields").GetProperty("thumbnail").ToString(),
                    Content = contentBody,
                    Source = "The Guardian",
                    Url = r.GetProperty("apiUrl").ToString(),
                    PublishAt = r.GetProperty("webPublicationDate").GetDateTime()
                };
                universalNewsEntities.Add(news);
            }

            Xunit.Assert.NotNull(universalNewsEntities);
            Xunit.Assert.NotEmpty(universalNewsEntities);
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
        public async Task ShouldGetNewsArticlesStreamAsync()
        {
            var product = new TheGuardianNewsFactoryServiceImp();

            var requestPlaceHolder = AppSettingsManager.Settings["TheGuardianUriPlaceHolder"];
            var request = string.Format(requestPlaceHolder
                , AppSettingsManager.Settings["TheGuardianServiceUrl"]
                , AppSettingsManager.Settings["Language"]
                , AppSettingsManager.Settings["TheGuardianApiSecret"]);

            var result = await product.GetNewsArticlesStreamAsync(request);
            Xunit.Assert.NotNull(result);
        }
        [Fact]
        public async Task ShouldParseNewsStreamToEntity()
        {
            var product = new TheGuardianNewsFactoryServiceImp();

            var requestPlaceHolder = AppSettingsManager.Settings["TheGuardianUriPlaceHolder"];
            var request = string.Format(requestPlaceHolder
                , AppSettingsManager.Settings["TheGuardianServiceUrl"]
                , AppSettingsManager.Settings["Language"]
                , AppSettingsManager.Settings["TheGuardianApiSecret"]);
            Stream content = await GetNewsArticleStreamAsync(request);
            var result = await product.ParseNewsStreamToEntitiesAsync(content);
            Xunit.Assert.NotNull(result);
            Xunit.Assert.NotEmpty(result);
        }
        [Fact]
        public async Task ShouldParseJsonElementToEntity()
        {
            var product = new TheGuardianNewsFactoryServiceImp();

            var requestPlaceHolder = AppSettingsManager.Settings["TheGuardianUriPlaceHolder"];
            var request = string.Format(requestPlaceHolder
                , AppSettingsManager.Settings["TheGuardianServiceUrl"]
                , AppSettingsManager.Settings["Language"]
                , AppSettingsManager.Settings["TheGuardianApiSecret"]);
            Stream content = await GetNewsArticleStreamAsync(request);
            var result = new List<UniversalNewsEntity>();
            using (var jsonDoc = await JsonDocument.ParseAsync(content))
            {

                /*First, we get the root element from the JsonDocument**/
                JsonElement root = jsonDoc.RootElement;
                JsonElement results = root.GetProperty("response").GetProperty("results");
                foreach (var r in results.EnumerateArray())
                {
                    result.Add(product.ParseJsonElementToEntity(r));
                }
            }

            Xunit.Assert.NotNull(result);
            Xunit.Assert.NotEmpty(result);
        }
        [Fact]
        public async Task ShouldParseNewsStreamToEntitiesAsync()
        {
            var product = new TheGuardianNewsFactoryServiceImp();

            var requestPlaceHolder = AppSettingsManager.Settings["TheGuardianUriPlaceHolder"];
            var request = string.Format(requestPlaceHolder
                , AppSettingsManager.Settings["TheGuardianServiceUrl"]
                , AppSettingsManager.Settings["Language"]
                , AppSettingsManager.Settings["TheGuardianApiSecret"]);
            Stream content = await GetNewsArticleStreamAsync(request);

            var result = await product.ParseNewsStreamToEntitiesAsync(content);
            Xunit.Assert.NotNull(result);
            Xunit.Assert.NotEmpty(result);
        }
    }
}
