using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TrueNewsFeeder.Shared;

namespace TrueNewsFeeder.Repositories.Services
{
    public class NewsServiceConsumer : IService
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public async Task<T> GetData<T>() where T : class, new()
        {
            try
            {
                var uriConstructed = String.Format(AppSettingsManager.Settings["UriHolder"], AppSettingsManager.Settings["Service"], AppSettingsManager.Settings["Country"], AppSettingsManager.Settings["AppSecret"]);
                var uri = new Uri(uriConstructed);
                var response = await _httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(json);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return new T();
        }
    }
}
