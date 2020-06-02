using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using TrueNewsFeeder.Core.ViewModels;
using TrueNewsFeeder.Models.NewsApi;
using TrueNewsFeeder.Repositories.Services.Implementation;

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
            //Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IUniversalNewsService, NewsServiceConsumer>();
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<BaseNewsFactoryService<News>, NewsApiNewsFactoryServiceImp>();
            RegisterAppStart<TrueNewsViewModel>();
        }
    }
}
