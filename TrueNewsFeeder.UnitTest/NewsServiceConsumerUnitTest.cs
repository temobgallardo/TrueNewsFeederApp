using System.Threading.Tasks;
using TrueNewsFeeder.Models.NewsApi;
using TrueNewsFeeder.Repositories.Services;
using Xunit;

namespace TrueNewsFeeder.UnitTest
{
    public class NewsServiceConsumerUnitTest
    {
        [Fact]
        public async Task ShouldGetDataOfTypeNewsMocked()
        {
            var service = new NewsServiceConsumerMock();
            var result = await service.GetData<News>();
            Assert.NotNull(result);
            Assert.NotEmpty(result.Articles);
        }

        [Fact]
        public async Task ShouldGetDataOfTypeNews()
        {
            var service = new NewsServiceConsumer();
            var result = await service.GetData<News>();
            Assert.NotNull(result);
            Assert.NotEmpty(result.Articles);
        }
    }
}
