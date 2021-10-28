using NUnit.Framework;
using TrueNewsFeeder.UITest.PageObjectPattern;
using TrueNewsFeeder.UITest.Pages;
using Xamarin.UITest;

namespace TrueNewsFeeder.UITest
{
    [TestFixture(Platform.Android)]
    public class HomePageTest: BaseTestFixture
    {
        public HomePageTest(Platform platform) : base(platform)
        {
        }

        [Test]
        public void LookForNews()
        {
            App.Repl();
            // Read Evaluate Print Loop
            new HomePage()
                .Search();
        }
    }
}
