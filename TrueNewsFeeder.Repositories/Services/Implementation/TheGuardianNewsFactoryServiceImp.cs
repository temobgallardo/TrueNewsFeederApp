using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrueNewsFeeder.Models;
using TrueNewsFeeder.Models.Guardian;
using TrueNewsFeeder.Repositories.Services.Implementation;
using TrueNewsFeeder.Shared;

namespace TrueNewsFeeder.Repositories.Services.Implemantation
{
    public class TheGuardianNewsFactoryServiceImp : BaseNewsFactoryService<TheGuardianNewsResponse>
    {
        public override async Task<IList<UniversalNewsEntity>> GetNewsArticlesAsync()
        {
            var requestPlaceHolder = AppSettingsManager.Settings["TheGuardianUriPlaceHolder"];
            var request = string.Format(requestPlaceHolder
                , AppSettingsManager.Settings["TheGuardianServiceUrl"]
                , AppSettingsManager.Settings["Language"]
                , AppSettingsManager.Settings["TheGuardianApiSecret"]);

            return await GetNewsArticlesAsync(request);
        }

        public override IList<UniversalNewsEntity> ParseTNewsToEntities(TheGuardianNewsResponse news) 
        {
            return news.Response.Results.Select(result => new UniversalNewsEntity
            {
                Content = result.Blocks.Body.FirstOrDefault().BodyTextSummary,
                Description = result.Blocks.Body.FirstOrDefault().BodyTextSummary.Substring(0, 253) + "...",
                PublishedAt = result.WebPublicationDate,
                Source = "The Guardian",
                Title = result.WebTitle,
                Url = result.WebUrl,
                UrlToImage = result.Fields.Thumbnail
            }).ToList();
        }
    }
}
