using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrueNewsFeeder.Models.NewsApi;
using Xunit;

namespace TrueNewsFeeder.UnitTest
{
    public class NewsServiceConsumerUnitTest
    {
        [Fact]
        public async Task<News> ShouldGetDataOfTypeNews() 
        {
            return await Task.FromResult(new News());
        } 
    }
}
