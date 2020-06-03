using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TrueNewsFeeder.Models;
using TrueNewsFeeder.Repositories.Services.Implemantation;
using TrueNewsFeeder.Repositories.Services.Interfaces;

namespace TrueNewsFeeder.Repositories.Services.Implementation
{
    public class NewsfeedManager : INewsfeedManager
    {
        private IList<INewsfeed> _sources;

        public NewsfeedManager()
        {
            //initilize
            //Add(new TheGuardianNewsFactoryServiceImp());
            //Add(new NewsApiNewsFactoryServiceImp());
        }

        public async Task<IList<UniversalNewsEntity>> GetNewsfeedAsync()
        {
            var newfeeds = new List<UniversalNewsEntity>();
            foreach (INewsfeed newsfeedSource in _sources)
            {
                try
                {
                    var newsEntities = await newsfeedSource.GetNewsfeedAsync();
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

        public void Add(INewsfeed source)
        {
            if (_sources == null)
            {
                _sources = new List<INewsfeed>();
            }

            _sources.Add(source);
        }

        public void Remove(INewsfeed source)
        {
            _sources?.Remove(source);
        }
    }
}
