using Google.Type;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TrueNewsFeeder.Models;
using TrueNewsFeeder.Repositories.Services.Interfaces;

namespace TrueNewsFeeder.Repositories.Services.Implementation
{
    public class NewsFeedManager : INewsFeedManager
    {
        private readonly IList<INewsFeedConnector> _sources;
        //private readonly FirestoreNewsRepositoryFactoryImp _dbsources;

        public NewsFeedManager()
        {
            _sources = new List<INewsFeedConnector>();
            //_dbsources = new FirestoreNewsRepositoryFactoryImp();
            //initilize
            //Add(new TheGuardianNewsRepositoryFactoryImp());
            //Add(new NewsApiNewsRepositoryFactoryImp());
        }

        public async Task<IList<UniversalNewsEntity>> GetNewsFeedAsync()
        {
            //var today = System.DateTime.Today;
            var newfeeds = new List<UniversalNewsEntity>();
            //newfeeds.AddRange(await _dbsources.GetNewsFeedAsync(today.ToDate()));

            //if (newfeeds != null && newfeeds.Any())
            //{
            //    return newfeeds;
            //}

            //newfeeds = new List<UniversalNewsEntity>();
            foreach (INewsFeedConnector newsfeedSource in _sources)
            {
                try
                {
                    var newsEntities = await newsfeedSource.GetNewsFeedAsync();
                    if (newsEntities != null && newsEntities.Any())
                    {
                        newfeeds.AddRange(newsEntities);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Failing on getting source from {newsfeedSource.GetType().Name}, message : {ex.Message}");
                }
            }

            return newfeeds;
        }

        public void Add(INewsFeedConnector source)
        {
            _sources?.Add(source);
        }

        public void Remove(INewsFeedConnector source)
        {
            _sources?.Remove(source);
        }

        public void Clear()
        {
            _sources?.Clear();
        }
    }
}
