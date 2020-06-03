using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrueNewsFeeder.Models;
using TrueNewsFeeder.Repositories.Services.Implemantation;
using TrueNewsFeeder.Repositories.Services.Interfaces;

namespace TrueNewsFeeder.Repositories.Services.Implementation
{
    public class NewsfeedFactory : INewsfeedFactory
    {
        public INewsfeed GetNewsfeed(NewsfeedFactorySource source)
        {
            switch (source)
            {
                case NewsfeedFactorySource.Guardian:
                    return new TheGuardianNewsFactoryServiceImp();
                case NewsfeedFactorySource.NewsAPI:
                    return new NewsApiNewsFactoryServiceImp();
                default:
                    throw new ArgumentException($"Type not implemented : {source}");
            }
        }
    }
}
