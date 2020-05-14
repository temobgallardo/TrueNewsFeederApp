using System.Collections.Generic;
using System.Threading.Tasks;
using TrueNewsFeeder.Models.NewsApi;

namespace TrueNewsFeeder.Repositories.Services.Interfaces
{
    public interface IService
    {
        Task<T> GetData<T>() where T: class, new();

        Task<T> GetData<T>(string url) where T : class, new();
    }
}