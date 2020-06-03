using System;
using TrueNewsFeeder.Repositories.Services.Interfaces;

namespace TrueNewsFeeder.Repositories.Services.Implementation
{
    public interface INewsfeedFactory
    {
        INewsfeed GetNewsfeed(NewsfeedFactorySource source);
    }

    public enum NewsfeedFactorySource
    {
        None = 0,
        Guardian = 1,
        NewsAPI = 2
    }
}
