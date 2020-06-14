using System.Collections.Generic;
using System.Threading.Tasks;
using TrueNewsFeeder.Models;
using Google.Cloud.Firestore;
using TrueNewsFeeder.Shared;
using System;
using Google.Type;
using System.Linq;
using System.Diagnostics;
using Google.Cloud.Firestore.V1;

namespace TrueNewsFeeder.Repositories.Services.Implementation
{
    public class FirestoreNewsRepositoryFactoryImp
    {
        private readonly FirestoreDb _firestore;

        public FirestoreNewsRepositoryFactoryImp()
        {
            try
            {
                var client = new FirestoreClientBuilder()
                {
                    JsonCredentials = AppSettingsManager.Settings["FirestoreSecrets"]
                };

                _firestore = FirestoreDb.Create(AppSettingsManager.Settings["FirestoreProjectId"], client.Build());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public async Task GetNewsFeedAsync(IList<UniversalNewsEntity> news)
        {
            //TODO: CHECK FOR NO INTERNET CONNECTION
            var newsDocRef = await _firestore.Collection(AppSettingsManager.Settings["FirestoreCollection"]).AddAsync(news);
            await newsDocRef.UpdateAsync("Timestamp", Google.Cloud.Firestore.Timestamp.GetCurrentTimestamp());
        }

        public async Task<IList<UniversalNewsEntity>> GetNewsFeedAsync(Date dayChoosen)
        {
            var tomorrow = System.DateTime.Today.AddDays(1);
            var newsDocRef = _firestore.Collection(AppSettingsManager.Settings["FirestoreCollection"]);
            var query = newsDocRef.WhereIn("PublishedAt", new[] { dayChoosen.ToDateTime(), tomorrow });

            var news = new List<UniversalNewsEntity>();
            QuerySnapshot newsSnapshots = await query.GetSnapshotAsync();

            if (newsSnapshots != null && newsSnapshots.Any())
            {
                return default;
            }

            foreach (DocumentSnapshot ns in newsSnapshots)
            {
                news.AddRange(ns.ConvertTo<IList<UniversalNewsEntity>>());
            }

            return news;
        }
    }
}
