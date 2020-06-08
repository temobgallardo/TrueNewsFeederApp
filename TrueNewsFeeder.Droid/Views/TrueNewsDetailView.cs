using Android.App;
using Android.OS;
using Android.Views;
using Android.Webkit;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using System;
using TrueNewsFeeder.Core.ViewModels;

namespace TrueNewsFeeder.Droid.Views
{
    [MvxActivityPresentation]
    [Activity(Theme = "@style/AppTheme", MainLauncher = false)]
    public class TrueNewsDetailView : MvxAppCompatActivity<TrueNewsDetailViewModel>
    {
        private WebView _webView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.true_news_detail_webview);
            SupportActionBar.Title = GetText(Resource.String.screen_detail_title);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            ViewModel.Article.Source = GetString(Resource.String.sources, ViewModel.Article.Source);

            SetWebViewInDetailView();
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

        public void SetWebViewInDetailView()
        {
            _webView = FindViewById<WebView>(Resource.Id.true_news_detail_webview);
            _webView.LoadUrl(ViewModel.Article.Url);
        }
    }
}