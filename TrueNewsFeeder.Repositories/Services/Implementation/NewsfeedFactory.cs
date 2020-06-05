using System;
using TrueNewsFeeder.Repositories.Services.Implemantation;
using TrueNewsFeeder.Repositories.Services.Interfaces;

namespace TrueNewsFeeder.Repositories.Services.Implementation
{
    public class NewsFeedFactory : INewsFeedRepositoriesFactory
    {
        public INewsFeedConnector GetNewsFeed(ENewsFeedFactorySource source)
        {
            switch (source)
            {
                case ENewsFeedFactorySource.Guardian:
                    return new TheGuardianNewsRepositoryFactoryImp();
                case ENewsFeedFactorySource.NewsAPI:
                    return new NewsApiNewsRepositoryFactoryImp();
                default:
                    throw new ArgumentException($"Type not implemented : {source}");
            }
        }
    }
}
