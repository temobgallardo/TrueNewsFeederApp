using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TrueNewsFeeder.Models.NewsApi;
using TrueNewsFeeder.Repositories.Services.Interfaces;

namespace TrueNewsFeeder.Repositories.Services.Implemantation
{
    class TheGuardianNewsFactoryServiceImp : INewsFactoryService
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<IList<UniversalNewsEntity>> GetNewsArticlesAsync()
        {
            return await GetNewsArticlesAsync("");
        }

        public async Task<IList<UniversalNewsEntity>> GetNewsArticlesAsync(string request)
        {
            var response = await _httpClient.GetAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return default;
            }

            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IList<UniversalNewsEntity>>(result);
        }
    }
}
