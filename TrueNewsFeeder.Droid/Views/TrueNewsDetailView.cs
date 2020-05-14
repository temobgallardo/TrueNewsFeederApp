using Android.App;
using Android.OS;
using MvvmCross.Platforms.Android.Presenters.Attributes;

namespace TrueNewsFeeder.Droid.Views
{
    [MvxActivityPresentation]
    [Activity(Theme ="@style/AppTheme", MainLauncher = false)]
    public class TrueNewsDetailView: Activity
    {
        protected override void OnCreate(Bundle savedInstanceState) 
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.true_news_detail);
        }


    }
}