using System.Collections.Generic;
using System.Threading.Tasks;

namespace TrueNewsFeeder.Repositories.Services
{
    public interface IService
    {
        Task<T> GetData<T>() where T: class, new();
    }
}