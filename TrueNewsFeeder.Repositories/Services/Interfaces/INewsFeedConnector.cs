using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrueNewsFeeder.Models;

namespace TrueNewsFeeder.Repositories.Services.Interfaces
{
    public interface INewsFeedConnector
    {
        Task<IList<UniversalNewsEntity>> GetNewsFeedAsync();
    }
}
