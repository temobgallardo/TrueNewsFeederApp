using System.Collections.Generic;
using System.Threading.Tasks;
using TrueNewsFeeder.Models;
using TrueNewsFeeder.Repositories.Services.Implementation;

namespace TrueNewsFeeder.Repositories.Services.Interfaces
{
    public interface IMultipleNewsSourceAccessorFactory
    {
        Task<IList<UniversalNewsEntity>> GetUniversalNewsFromSources();
        Task<IList<UniversalNewsEntity>> GetUniversalNewsFromSource<T>(BaseNewsFactoryService<T> creator) where T: class, new();
    }
}
