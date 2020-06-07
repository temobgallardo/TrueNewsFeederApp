using System.Collections.Generic;
using System.Threading.Tasks;
using TrueNewsFeeder.Models;

namespace TrueNewsFeeder.Repositories.Services.Interfaces
{
    public interface INewsRepositoryFactory<T> where T: class, new()
    {
        Task<IList<UniversalNewsEntity>> GetNewsArticlesAsync();
        Task<IList<UniversalNewsEntity>> GetNewsArticlesAsync(string request);
        Task<string> GetNewsJsonStringAsync(string request);
        T GetLocalNewsTypeData(string newsJson);
        IList<UniversalNewsEntity> ParseTNewsToEntities(T news); 
    }
}
