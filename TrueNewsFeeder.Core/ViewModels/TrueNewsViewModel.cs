using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrueNewsFeeder.Models;
using TrueNewsFeeder.Repositories.Services.Interfaces;

namespace TrueNewsFeeder.Core.ViewModels
{
    public class TrueNewsViewModel : BaseViewModel
    {
        private readonly INewsFeedManager _newsRepository;
        private readonly INewsFeedRepositoriesFactory _newsfeedFactory;

        public MvxObservableCollection<UniversalNewsEntity> Articles { get; private set; }
        public MvxObservableCollection<UniversalNewsEntity> CachedArticles { get; private set; }
        public IMvxCommand<string> FilterNewsCommandAsync { get; private set; }
        public IMvxAsyncCommand<UniversalNewsEntity> OnTrueNewsRowSelectedCommand { get; private set; }
        public IMvxAsyncCommand GetNewsCommandAsync { get; private set; }

        public TrueNewsViewModel(IMvxNavigationService mvxNavigationService,
            INewsFeedManager newsRepository,
            INewsFeedRepositoriesFactory newsfeedFactory) : base(mvxNavigationService)
        {
            _newsfeedFactory = newsfeedFactory;
            _newsRepository = newsRepository;
            Articles = new MvxObservableCollection<UniversalNewsEntity>();
            CachedArticles = new MvxObservableCollection<UniversalNewsEntity>();
            GetNewsCommandAsync = new MvxAsyncCommand(GetNewsArticleAsync);
            FilterNewsCommandAsync = new MvxCommand<string>(FilterNewsByTitle);
            OnTrueNewsRowSelectedCommand = new MvxAsyncCommand<UniversalNewsEntity>(LeapToTrueNewsDetailViewModel);

            _newsRepository.Add(_newsfeedFactory.GetNewsFeed(ENewsFeedFactorySource.Guardian));
            _newsRepository.Add(_newsfeedFactory.GetNewsFeed(ENewsFeedFactorySource.NewsAPI));

        }

        private async Task LeapToTrueNewsDetailViewModel(UniversalNewsEntity article)
        {
            await _navigationService.Navigate<TrueNewsDetailViewModel, UniversalNewsEntity>(article);
        }

        private void FilterNewsByTitle(string toSearch)
        {
            /**
             * CachedArticles was initialized in Initialize()
             */
            if (string.IsNullOrEmpty(toSearch))
            {
                Articles.Clear();
                Articles.AddRange(CachedArticles);
            }
            else
            {
                Articles.Clear();
                Articles.AddRange(CachedArticles.Where(article => 
                article != null 
                && article.Title != null 
                && article.Title.ToLower().Contains(toSearch)));
            }
        }

        public override async Task Initialize()
        {
            var articles = await GetArticlesFromNewsServiceAsync();

            if (articles == null || !articles.Any())
            {
                return;
            }

            Articles.AddRange(articles);
            CachedArticles.AddRange(articles);
        }

        public async Task<IList<UniversalNewsEntity>> GetArticlesFromNewsServiceAsync()
        {
            //var request = string.Format(
            //   AppSettingsManager.Settings["UriHolderBySources"]
            //   , AppSettingsManager.Settings["Service"]
            //   , AppSettingsManager.Settings["Language"]
            //   , AppSettingsManager.Settings["AppSecret"]);
            var articles = await _newsRepository.GetNewsFeedAsync();

            if (articles == null)
            {
                return default;
            }

            return articles;
        }

        // Todo: More Functional Programming Here!
        private async Task GetNewsArticleAsync()
        {
            var articles = await _newsRepository.GetNewsFeedAsync();
            Articles.AddRange(articles);
        }
    }
}