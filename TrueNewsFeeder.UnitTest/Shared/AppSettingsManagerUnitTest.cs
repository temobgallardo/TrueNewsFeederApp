using TrueNewsFeeder.Shared;
using Xunit;

namespace TrueNewsFeeder.UnitTest.Shared
{
    public class AppSettingsManagerUnitTest
    {
        [Fact]
        public void ShouldReturnServiceUri()
        {
            // Arrange
            var expected = "https://newsapi.org/v2";
            // Act
            var result = AppSettingsManager.Settings["Service"];
            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ShouldReturnEmpty() 
        {
            var expectedResult = "";
            var result = AppSettingsManager.Settings["Hello"];
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void ShouldReturnService()
        {
            var expectedResult = "https://newsapi.org/v2";
            var result = AppSettingsManager.Settings["Service"];
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void ShouldReturnServiceEverything()
        {
            var expectedResult = "https://newsapi.org/v2/everything";
            var result = AppSettingsManager.Settings["ServiceEverything"];
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void ShouldReturnAppSecret()
        {
            var expectedResult = "e7212367df3e433e8832bc11a4ba5711";
            var result = AppSettingsManager.Settings["AppSecret"];
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void ShouldReturnLanguage()
        {
            var expectedResult = "en";
            var result = AppSettingsManager.Settings["Language"];
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void ShouldReturnUriHolder()
        {
            var expectedResult = "{0}/top-headlines?country={1}&apiKey={2}";
            var result = AppSettingsManager.Settings["UriHolder"];
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void ShouldReturnUriHolderBySources()
        {
            var expectedResult = "{0}/sources?language={1}&apiKey={2}";
            var result = AppSettingsManager.Settings["UriHolderBySources"];
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void ShouldReturnUriHolderEverythingBySource()
        {
            var expectedResult = "{0}?sources={1}&apiKey={2}";
            var result = AppSettingsManager.Settings["UriHolderEverythingBySource"];
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void ShouldReturnUriHolderEverythingAndDomain()
        {
            var expectedResult = "{0}?domains={1}&apiKey={2}";
            var result = AppSettingsManager.Settings["UriHolderEverythingAndDomain"];
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void ShouldReturnMockFileName()
        {
            var expectedResult = "Mockdata/mockdata.json";
            var result = AppSettingsManager.Settings["MockFileName"];
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void ShouldReturnDomains()
        {
            var expectedResult = "wsj.com,bloomberg.com,nytimes.com,theguardian.com,bbc.com/news,news.yahoo.com,ft.com,reuters.com";
            var result = AppSettingsManager.Settings["Domains"];
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void ShouldReturnCountries()
        {
            var expectedResult = "";
            var result = AppSettingsManager.Settings["Countries"];
            Assert.Equal(expectedResult, result);
        }

    }
}