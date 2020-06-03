using System;
namespace TrueNewsFeeder.Repositories.Services.Interfaces
{
    public interface INewsfeedSourceManager
    {
        void Add(INewsfeed source);
        void Remove(INewsfeed source);
    }

    public interface INewsfeedManager : INewsfeedSourceManager, INewsfeed
    {


    }

}
