using System;
using TrueNewsFeeder.Repositories.Services.Implemantation;
using TrueNewsFeeder.Repositories.Services.Interfaces;

namespace TrueNewsFeeder.Repositories.Services.Implementation
{
    //TODO: This violates the OPEN-CLOSE Principle. An Enum is not open for extensions. https://blog.usejournal.com/factory-design-pattern-c-a330955b9ed6
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
