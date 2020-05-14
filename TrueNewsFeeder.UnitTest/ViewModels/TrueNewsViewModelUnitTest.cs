using Moq;
using MvvmCross.Base;
using MvvmCross.Navigation;
using MvvmCross.Core.Views;
using MvvmCross.Tests;
using NUnit.Framework;
using TrueNewsFeeder.Core.ViewModels;
using TrueNewsFeeder.Repositories.Services.Interfaces;
using TrueNewsFeeder.UnitTest.ViewModels;
using System;

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
            var newsService = new Mock<IUniversalNewsService>();
            Ioc.RegisterSingleton(newsService.Object);
            MockDispatcher = new MockDispatcher();
            Ioc.RegisterSingleton<IMvxViewDispatcher>(MockDispatcher);
            Ioc.RegisterSingleton<IMvxMainThreadDispatcher>(MockDispatcher);
        }

        //[Test]
        //public void ShouldFilterTheArticlesByTitle()
        //{
        //    base.Setup();

        //    var newsApiService = new Mock<IUniversalNewsService>();
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
