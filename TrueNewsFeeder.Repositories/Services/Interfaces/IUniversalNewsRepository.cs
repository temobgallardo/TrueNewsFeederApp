using System.Collections.Generic;
using System.Threading.Tasks;
using TrueNewsFeeder.Models.NewsApi;

namespace TrueNewsFeeder.Repositories.Services.Interfaces
{
    public interface IUniversalNewsRepository
    {
        Task<News> GetNews(string request);
        Task<IList<Article>> GetNewsArticles();
        Task<IList<Article>> GetNewsArticles(string request);
        Task<News> GetNewsSources();
        Task<News> GetNewsSources(string request);
    }
}
