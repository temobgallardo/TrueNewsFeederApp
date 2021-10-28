using NUnit.Framework;
using System;
using Xamarin.UITest;

namespace TrueNewsFeeder.UITest.PageObjectPattern
{
    public class BaseTestFixtureAfterLogin : BaseTestFixture
    {
        public BaseTestFixtureAfterLogin(Platform platform) : base(platform)
        {}

        [SetUp]
        public override void BeforeEachTest()
        {
            base.BeforeEachTest();
            Login();
        }

        public void Login()
        {
            Console.WriteLine("Estoy haciendo loging");
        }
    }
}
