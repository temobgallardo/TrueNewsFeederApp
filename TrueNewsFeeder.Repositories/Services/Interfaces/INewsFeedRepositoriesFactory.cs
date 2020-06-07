namespace TrueNewsFeeder.Repositories.Services.Interfaces
{
    public interface INewsFeedRepositoriesFactory
    {
        INewsFeedConnector GetNewsFeed(ENewsFeedFactorySource source);
    }

    public enum ENewsFeedFactorySource
    {
        None = 0,
        Guardian = 1,
        NewsAPI = 2
    }
}
