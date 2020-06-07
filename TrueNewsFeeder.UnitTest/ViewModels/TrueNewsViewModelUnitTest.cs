using Moq;
using MvvmCross.Base;
using MvvmCross.Core.Views;
using MvvmCross.Tests;
using NUnit.Framework;
using TrueNewsFeeder.Repositories.Services.Interfaces;
using TrueNewsFeeder.UnitTest.ViewModels;

namespace TrueNewsFeeder.UnitTest
{
    [TestFixture]
    public class TrueNewsViewModelUnitTest : MvxIoCSupportingTest
    {
        protected MockDispatcher MockDispatcher
        {
            get;
            private set;
        }

        protected override void AdditionalSetup()
        {
            var newsService = new Mock<IUniversalNewsRepository>();
            Ioc.RegisterSingleton(newsService.Object);
            MockDispatcher = new MockDispatcher();
            Ioc.RegisterSingleton<IMvxViewDispatcher>(MockDispatcher);
            Ioc.RegisterSingleton<IMvxMainThreadDispatcher>(MockDispatcher);
        }

        //[Test]
        //public void ShouldFilterTheArticlesByTitle()
        //{
        //    base.Setup();

        //    var newsApiService = new Mock<IUniversalNewsRepository>();
        //    var navService = new Mock<IMvxNavigationService>();
        //    var trueNewsViewModel = new TrueNewsViewModel(navService.Object, newsApiService.Object);

        //    Assert.Throws<Exception>(
        //        delegate {
        //            trueNewsViewModel
        //            .FilterNewsCommandAsync
        //            .Execute("Title");
        //            }
        //        );
        //}
    }
}
