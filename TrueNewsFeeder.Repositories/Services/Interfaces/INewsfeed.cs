using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrueNewsFeeder.Models;

namespace TrueNewsFeeder.Repositories.Services.Interfaces
{
    public interface INewsfeed
    {
        Task<IList<UniversalNewsEntity>> GetNewsfeedAsync();
    }
}
