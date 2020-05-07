using Android.App;
using Android.OS;
using TrueNewsFeeder.Core.ViewModels;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Droid.Support.V7.AppCompat;
using Android.Views;
using static Android.Support.V7.Widget.SearchView;
using Android.Support.V7.Widget;

namespace TrueNewsFeeder.Droid.Views
{
    [MvxActivityPresentation]
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class TrueNewsView : MvxAppCompatActivity<TrueNewsViewModel>, IOnQueryTextListener, IMenuItemOnActionExpandListener
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.true_news_view);
            SupportActionBar.Title = ViewModel.Title;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.true_news_menu, menu);

            var item = menu.FindItem(Resource.Id.action_news_search);
            var _searchView = item.ActionView as SearchView;
            _searchView.SetOnQueryTextListener(this);
            item.SetOnActionExpandListener(this);
            _searchView.SetIconifiedByDefault(false);
            return base.OnCreateOptionsMenu(menu);
        }

        public bool OnQueryTextChange(string newText)
        {
            ViewModel.FilterNewsCommandAsync.Execute(newText);
            return true;
        }

        public bool OnQueryTextSubmit(string newText)
        {

            ViewModel.FilterNewsCommandAsync.Execute(newText);
            return true;
        }

        public bool OnMenuItemActionCollapse(IMenuItem item)
        {
            return true;
        }

        public bool OnMenuItemActionExpand(IMenuItem item)
        {
            return true;
        }
    }
}