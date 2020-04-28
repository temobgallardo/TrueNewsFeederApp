using System;
using TrueNewsFeeder.Shared;
using Xunit;

namespace TrueNewsFeeder.UnitTest
{
    public class AppSettingsManagerUnitTest
    {
        [Fact]
        public void ShouldReturnServiceUri()
        {
            // Arrange
            var expected = "http://newsapi.org/v2/top-headlines";
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
    }
}