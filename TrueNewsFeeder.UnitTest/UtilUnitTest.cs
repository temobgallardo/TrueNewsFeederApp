using System.IO;
using TrueNewsFeeder.Utils;
using Xunit;
using System.Windows;
using System.Reflection;
using TrueNewsFeeder.Repositories.Services;

namespace TrueNewsFeeder.UnitTest
{
    public class UtilUnitTest
    {
        [Fact]
        public void ShouldGetNonEmptyString()
        {
            //From the assembly where this code lives!
            //this.GetType().Assembly.GetManifestResourceNames();
            //or from the entry point to the application - there is a difference!
            //Assembly.GetExecutingAssembly().GetManifestResourceNames()
            var fileName = "mockdata.json";
            // I pass the NewServiceConsumer typeof becouse the data is located in that namespace
            var result = Util.Instance.ReadResourceFile(fileName, typeof(NewsServiceConsumer));
            Assert.NotEmpty(result.Result);
        }
    }
}
