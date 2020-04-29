using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using TrueNewsFeeder.Models.NewsApi;
using TrueNewsFeeder.Utils;

namespace TrueNewsFeeder.Repositories.Services
{
    public class NewServiceConsumerMock : IService
    {
        
        public async Task<T> GetData<T>() where T : class, new()
        {
            var data = await Util.Instance.ReadResourceFile("mockdata.json", typeof(NewsServiceConsumer));

            var json = JsonConvert.DeserializeObject<News>(data);

            // TODO: Test this out
            return json as T;
        }
    }
}
