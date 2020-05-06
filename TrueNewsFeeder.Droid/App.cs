using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using TrueNewsFeeder.Core.ViewModels;
using TrueNewsFeeder.Repositories.Services;

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

            //Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IService, NewServiceConsumerMock>();
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IService, NewsServiceConsumer>();
            RegisterAppStart<TrueNewsViewModel>();
        }
    }
}
