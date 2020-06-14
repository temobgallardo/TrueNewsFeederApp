using Newtonsoft.Json;
using System.Threading.Tasks;
using TrueNewsFeeder.Repositories.Services.Interfaces;
using TrueNewsFeeder.Utils;

namespace TrueNewsFeeder.Repositories.Services.Implemantation
{
    public class NewsServiceConsumerMock : IService
    {
        
        public async Task<T> GetData<T>() where T : class, new()
        {
            var data = await Util.Instance.ReadResourceFile("mockdata.json", typeof(TheGuardianNewsRepositoryFactoryImp));

            var json = JsonConvert.DeserializeObject<T>(data);

            return json;
        }

        public async Task<T> GetData<T>(string url) where T : class, new()
        {
            var data = await Util.Instance.ReadResourceFile("mockdata.json", typeof(TheGuardianNewsRepositoryFactoryImp));

            var json = JsonConvert.DeserializeObject<T>(data);

            return json;
        }
    }
}
