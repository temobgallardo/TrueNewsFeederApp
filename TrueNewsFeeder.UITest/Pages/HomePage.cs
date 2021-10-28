using System.Linq;
using TrueNewsFeeder.UITest.PageObjectPattern;
using Xamarin.UITest.Queries;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace TrueNewsFeeder.UITest.Pages
{
    public class HomePage : BasePage
    {
        public Query SearchButton = x => x.Marked("search");
        public AppResult[] NewsResults => App.Query(x => x.Marked("TrueNewsFeed"));

        protected override PlatformQuery Trait => new PlatformQuery()
        {
            Android = x => x.Marked("True News Feed")
        };

        public HomePage Search(string news = "Coronavirus")
        {
            App.Tap(SearchButton);
            App.WaitForElement(SearchButton);
            App.EnterText(SearchButton, news);
            App.PressEnter();

            return this;
        }
        public void ClickOverFirstNew()
        {
            var result = NewsResults.First();
            App.TapCoordinates(result.Rect.CenterX, result.Rect.CenterY);   
        }
    }
}
