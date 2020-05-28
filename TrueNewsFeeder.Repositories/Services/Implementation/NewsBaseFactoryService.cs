using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TrueNewsFeeder.Models.NewsApi;
using TrueNewsFeeder.Repositories.Services.Interfaces;

namespace TrueNewsFeeder.Repositories.Services.Implementation
{
    public abstract class NewsBaseFactoryService : INewsFactoryService
    {
        protected readonly HttpClient _httpClient = new HttpClient();

        public abstract Task<IList<UniversalNewsEntity>> GetNewsArticlesAsync();
        public abstract Task<IList<UniversalNewsEntity>> GetNewsArticlesAsync(string request);
        public abstract Task<Stream> GetNewsArticlesStreamAsync(string request);
        public abstract UniversalNewsEntity ParseJsonElementToEntity(JsonElement jElement);
        public abstract Task<IList<UniversalNewsEntity>> ParseNewsStreamToEntitiesAsync(Stream newsStream);
    }
}
