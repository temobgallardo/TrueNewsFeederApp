using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TrueNewsFeeder.Models.NewsApi;
using TrueNewsFeeder.Repositories.Services.Interfaces;

namespace TrueNewsFeeder.Repositories.Services.Implementation
{
    public class UniversalNewsServiceImp : IUniversalNewsService
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public async Task<UniversalNewsEntity> GetNews()
        {
            throw new NotImplementedException();
        }

        public Task<News> GetNews(string request)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Article>> GetNewsArticles()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Article>> GetNewsArticles(string request)
        {
            throw new NotImplementedException();
        }

        public Task<News> GetNewsSources()
        {
            throw new NotImplementedException();
        }

        public Task<News> GetNewsSources(string request)
        {
            throw new NotImplementedException();
        }
    }
}
