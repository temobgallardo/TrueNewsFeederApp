using System;
using Xamarin.UITest;

namespace TrueNewsFeeder.UITest.PageObjectPattern
{
    public class AppManager
    {
        private const string ApkPath = @"C:\Users\temoB\source\repos\TrueNewsFeeder\TrueNewsFeeder.Droid\bin\Release\com.companyname.truenewsfeeder.droid-Signed.apk";

        static IApp app;
        public static IApp App
        {
            get
            {
                if (app == null)
                {
                    if (app == null)
                        throw new NullReferenceException("'AppManager.App' not set. Call 'AppManager.StartApp()' before trying to access it.");
                }

                return app;
            }
        }

        static Platform? platform;
        public static Platform Platform
        {
            get
            {
                if (platform == null)
                {
                    throw new NullReferenceException("'AppManager.Platform' not set.");
                }

                return platform.Value;
            }

            set
            {
                platform = value;
            }
        }

        public static void StartApp()
        {
            if (Platform == Platform.Android)
            {
                app = ConfigureApp
                    .Android
                    .ApkFile(ApkPath)
                    .StartApp();
            }
        }
    }
}
