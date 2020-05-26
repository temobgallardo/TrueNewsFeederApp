using System.Collections.Generic;
using System.Threading.Tasks;
using TrueNewsFeeder.Models.NewsApi;

namespace TrueNewsFeeder.Repositories.Services.Interfaces
{
    interface INewsFactoryService
    {
        Task<IList<UniversalNewsEntity>> GetNewsArticlesAsync();
        Task<IList<UniversalNewsEntity>> GetNewsArticlesAsync(string request);
    }
}
