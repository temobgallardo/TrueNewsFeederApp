using System;
namespace TrueNewsFeeder.Repositories.Services.Interfaces
{
    public interface INewsfeedSourceManager
    {
        void Add(INewsfeed source);
        void Remove(INewsfeed source);
        void Clear();
    }

    public interface INewsfeedManager : INewsfeedSourceManager, INewsfeed
    {


    }

}
