using Android.App;
using Android.OS;
using Android.Views;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using TrueNewsFeeder.Core.ViewModels;

namespace TrueNewsFeeder.Droid.Views
{
    [MvxActivityPresentation]
    [Activity(Theme = "@style/AppTheme", MainLauncher = false)]
    public class TrueNewsDetailView: MvxAppCompatActivity<TrueNewsDetailViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState) 
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.true_news_detail);
            SupportActionBar.Title = GetText(Resource.String.screen_detail_title);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            ViewModel.Article.Source.Name = GetString(Resource.String.sources, ViewModel.Article.Source.Name);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    ViewModel.GoBackCommand.Execute();
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }
    }
}