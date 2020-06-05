using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TrueNewsFeeder.Models;
using TrueNewsFeeder.Repositories.Services.Interfaces;

namespace TrueNewsFeeder.Repositories.Services.Implementation
{
    public abstract class BaseNewsRepositoryFactory<T> : INewsRepositoryFactory<T> where T: class, new()
    {
        protected readonly HttpClient _httpClient = new HttpClient();
        protected string tag = typeof(BaseNewsRepositoryFactory<T>).Name;

        public T GetLocalNewsTypeData(string news)
        {
            return JsonConvert.DeserializeObject<T>(news);
        }
        public abstract Task<IList<UniversalNewsEntity>> GetNewsArticlesAsync();
        public async Task<IList<UniversalNewsEntity>> GetNewsArticlesAsync(string request)
        {
            try
            {
                var resultedJson = await GetNewsJsonStringAsync(request);

                return ParseTNewsToEntities(GetLocalNewsTypeData(resultedJson));
            }
            catch (Exception e)
            {
                throw new Exception(tag, e);
            }
        }
        public async Task<string> GetNewsJsonStringAsync(string request)
        {
            var response = await _httpClient.GetAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return default;
            }

            return await response.Content.ReadAsStringAsync();
        }
        public abstract IList<UniversalNewsEntity> ParseTNewsToEntities(T news);
    }
}
