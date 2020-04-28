using System.Threading.Tasks;
using TrueNewsFeeder.Utils;

namespace TrueNewsFeeder.Repositories.Services
{
    public class NewServiceConsumerMock : IService
    {
        
        public async Task<T> GetData<T>() where T : class, new()
        {
            var data = await Util.Instance.ReadResourceFile("mockdata.json", typeof(NewsServiceConsumer));

            return new T();
        }
    }
}
