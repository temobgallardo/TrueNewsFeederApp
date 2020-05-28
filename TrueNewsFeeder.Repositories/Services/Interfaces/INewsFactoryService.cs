using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using TrueNewsFeeder.Models.NewsApi;

namespace TrueNewsFeeder.Repositories.Services.Interfaces
{
    interface INewsFactoryService
    {
        Task<IList<UniversalNewsEntity>> GetNewsArticlesAsync();
        Task<IList<UniversalNewsEntity>> GetNewsArticlesAsync(string request);
        Task<Stream> GetNewsArticlesStreamAsync(string request);
        Task<IList<UniversalNewsEntity>> ParseNewsStreamToEntitiesAsync(Stream newsStream);
        UniversalNewsEntity ParseJsonElementToEntity(JsonElement jElement);
    }
}
