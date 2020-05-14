using System.Collections.Generic;
using System.Threading.Tasks;
using TrueNewsFeeder.Models.NewsApi;

namespace TrueNewsFeeder.Repositories.Services.Interfaces
{
    public interface IUniversalNewsService
    {
        Task<News> GetNews(string request);
        Task<IList<Article>> GetNewsArticle();
        Task<IList<Article>> GetNewsArticle(string request);
        Task<News> GetNewsSources();
        Task<News> GetNewsSources(string request);
    }
}
