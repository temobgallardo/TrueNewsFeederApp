using System.Net.Http;
using System.Threading.Tasks;
using TrueNewsFeeder.Shared;
using Xunit;

namespace TrueNewsFeeder.UnitTest
{
    public class TheGuardianNewsFactoryServiceImpUnitTest
    {
        private readonly HttpClient _client = new HttpClient();

        public async Task<byte[]> GetNewsArticleAsync(string request)
        {
            var response = await _client.GetAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return default;
            }

            return await response.Content.ReadAsByteArrayAsync();
        }
        [Fact]
        public async Task ShouldGetNewsArticleAsync()
        {
        }

        [Fact]
        public async Task ShouldGetNewsArticleAsyncWithArg()
        {
            var requestPlaceHolder = AppSettingsManager.Settings["TheGuardianUriPlaceHolder"];
            var request = string.Format(requestPlaceHolder
                , AppSettingsManager.Settings["TheGuardianServiceUrl"]
                , AppSettingsManager.Settings["Language"]
                , AppSettingsManager.Settings["TheGuardianApiSecret"]);
            byte[] content = await GetNewsArticleAsync(request);
            Assert.NotNull(content);
            Assert.NotEmpty(content);
        }
    }
}
