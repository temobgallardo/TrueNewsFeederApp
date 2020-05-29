using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TrueNewsFeeder.Models.NewsApi;
using TrueNewsFeeder.Repositories.Services.Implementation;
using TrueNewsFeeder.Shared;

namespace TrueNewsFeeder.Repositories.Services.Implemantation
{
    public class TheGuardianNewsFactoryServiceImp : NewsBaseFactoryService
    {
        public override async Task<IList<UniversalNewsEntity>> GetNewsArticlesAsync()
        {
            var requestPlaceHolder = AppSettingsManager.Settings["TheGuardianUriPlaceHolder"];
            var request = string.Format(requestPlaceHolder
                , AppSettingsManager.Settings["TheGuardianServiceUrl"]
                , AppSettingsManager.Settings["Language"]
                , AppSettingsManager.Settings["TheGuardianApiSecret"]);

            return await GetNewsArticlesAsync(request);
        }

        public override async Task<IList<UniversalNewsEntity>> GetNewsArticlesAsync(string request)
        {

            var content = await GetNewsArticlesStreamAsync(request);

            return await ParseNewsStreamToEntitiesAsync(content);
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
            jElement.GetProperty("blocks").TryGetProperty("body", out JsonElement body);
            var contentBody = body.EnumerateArray().FirstOrDefault().GetProperty("bodyTextSummary").GetString();

            return new UniversalNewsEntity
            {
                Title = jElement.GetProperty("webTitle").GetString(),
                Description = contentBody.ToString().Substring(0, 253) + "...",
                UrlToImage = jElement.GetProperty("fields").GetProperty("thumbnail").ToString(),
                Content = contentBody,
                Source = "The Guardian",
                Url = jElement.GetProperty("apiUrl").ToString(),
                PublishedAt = jElement.GetProperty("webPublicationDate").GetDateTime()
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
                JsonElement results = root.GetProperty("response").GetProperty("results");
                foreach (var r in results.EnumerateArray())
                {
                    universalNewsEntities.Add(ParseJsonElementToEntity(r));
                }
            }

            return universalNewsEntities;
        }
    }
}
