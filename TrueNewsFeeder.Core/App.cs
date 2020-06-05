using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using TrueNewsFeeder.Core.ViewModels;
using TrueNewsFeeder.Models.NewsApi;
using TrueNewsFeeder.Repositories.Services.Implementation;
using TrueNewsFeeder.Repositories.Services.Interfaces;

namespace TrueNewsFeeder.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            // Mock _service
            //Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IService, NewServiceConsumerMock>();
            //Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IUniversalNewsRepository, NewsServiceConsumer>();
            //Mvx.IoCProvider.LazyConstructAndRegisterSingleton<BaseNewsRepositoryFactory<News>, NewsApiNewsRepositoryFactoryImp>();
            //Mvx.IoCProvider.LazyConstructAndRegisterSingleton<INewsFeedConnector, NewsFeedManager>();
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<INewsFeedManager, NewsFeedManager>();
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<INewsFeedRepositoriesFactory, NewsFeedFactory>(); 
            RegisterAppStart<TrueNewsViewModel>();
        }
    }
}
