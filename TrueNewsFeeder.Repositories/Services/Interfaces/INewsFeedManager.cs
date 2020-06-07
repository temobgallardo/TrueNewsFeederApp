using System;
namespace TrueNewsFeeder.Repositories.Services.Interfaces
{
    public interface INewsFeedSourceManager
    {
        void Add(INewsFeedConnector source);
        void Remove(INewsFeedConnector source);
        void Clear();
    }

    public interface INewsFeedManager : INewsFeedSourceManager, INewsFeedConnector
    { }

}
