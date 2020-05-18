using Android.App;
using Android.Content.PM;
using Android.OS;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platforms.Android.Presenters.Attributes;

namespace TrueNewsFeeder.Droid.Views
{
    [MvxActivityPresentation]
    [Activity(Theme = "@style/AppTheme"
        , NoHistory = true
        , ScreenOrientation = ScreenOrientation.Portrait
        , MainLauncher = true)]
    public class TrueNewsSplashView : MvxSplashScreenAppCompatActivity
    {
        public TrueNewsSplashView () : base(Resource.Layout.true_news_splash)
        {
        }
    }
}