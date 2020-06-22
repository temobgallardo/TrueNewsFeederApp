using System;
using Android.App;
using Android.Runtime;
using Firebase;
using Firebase.Firestore;
using MvvmCross.Droid.Support.V7.AppCompat;
using TrueNewsFeeder.Core;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace TrueNewsFeeder.Droid
{
    [Application]
    class MainApplication : MvxAppCompatApplication<Setup, App>
    {
        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        { }

        public override void OnCreate()
        {
            base.OnCreate();

            AppCenter.Start("d5ad5ac4-fe79-4421-af13-e6591cafdd55",
                   typeof(Analytics), typeof(Crashes));

            Analytics.TrackEvent("Video clicked");

            GetFirestore();
        }

        public FirebaseFirestore GetFirestore()
        {
            var options = new FirebaseOptions.Builder()
                .SetProjectId("true-news-feed-database")
                .SetApplicationId("true-news-feed-database")
                .SetApiKey("AIzaSyANwKV7QnXzfsL_yZGgrnl1E3ZkG3TFyBQ")
                .SetDatabaseUrl("https://true-news-feed-database.firebaseio.com")
                .SetStorageBucket("true-news-feed-database.appspot.com")
                .Build();
            var firebaseApp = FirebaseApp.InitializeApp(this, options);
            return FirebaseFirestore.GetInstance(firebaseApp);
        }
    }
}