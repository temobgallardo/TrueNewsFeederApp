using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using TrueNewsFeeder.Core.ViewModels;
using TrueNewsFeeder.Repositories.Services.Implemantation;
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
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IUniversalNewsService, NewsServiceConsumer>();
            //Mvx.IoCProvider.LazyConstructAndRegisterSingleton<NewsBaseFactoryService, NewsApiNewsFactoryServiceImp>();
            RegisterAppStart<TrueNewsViewModel>();
        }
    }
}
