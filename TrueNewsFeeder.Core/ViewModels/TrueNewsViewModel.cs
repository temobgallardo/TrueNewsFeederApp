using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrueNewsFeeder.Models.NewsApi;
using TrueNewsFeeder.Repositories.Services.Interfaces;
using TrueNewsFeeder.Shared;

namespace TrueNewsFeeder.Core.ViewModels
{
    public class TrueNewsViewModel : BaseViewModel
    {
        private readonly IUniversalNewsService _service;

        public MvxObservableCollection<Article> Articles { get; private set; }
        public MvxObservableCollection<Article> CachedArticles { get; private set; }
        public IMvxCommand<string> FilterNewsCommandAsync { get; private set; }
        public IMvxAsyncCommand<Article> OnTrueNewsRowSelectedCommand { get; private set; }
        public IMvxAsyncCommand GetNewsCommandAsync { get; private set; }

        public TrueNewsViewModel(IMvxNavigationService mvxNavigationService, IUniversalNewsService serviceApi) : base(mvxNavigationService)
        {
            _service = serviceApi;
            Articles = new MvxObservableCollection<Article>();
            CachedArticles = new MvxObservableCollection<Article>();
            GetNewsCommandAsync = new MvxAsyncCommand(GetNewsArticleAsync);
            FilterNewsCommandAsync = new MvxCommand<string>(FilterNewsByTitle);
            OnTrueNewsRowSelectedCommand = new MvxAsyncCommand<Article>(LeapToTrueNewsDetailViewModel);
        }

        private async Task LeapToTrueNewsDetailViewModel(Article article)
        {
            await _navigationService.Navigate<TrueNewsDetailViewModel, Article>(article);
        }

        private void FilterNewsByTitle(string toSearch)
        {
            /**
             * CachedArticles was initialized in ViewAppearing()
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

        public override async void ViewAppearing()
        {
            base.ViewAppearing();
            var articles = await GetArticlesFromNewsServiceAsync();

            if (articles == null || !articles.Any())
            {
                return;
            }

            Articles.AddRange(articles);
            CachedArticles.AddRange(articles);
        }

        public async Task<IList<Article>> GetArticlesFromNewsServiceAsync()
        {
            var request = string.Format(
               AppSettingsManager.Settings["UriHolderBySources"]
               , AppSettingsManager.Settings["Service"]
               , AppSettingsManager.Settings["Language"]
               , AppSettingsManager.Settings["AppSecret"]);
            var articles = await _service.GetNewsArticles(request);

            if (articles == null)
            {
                return default;
            }

            return articles;
        }

        // Todo: More Functional Programming Here!
        private async Task GetNewsArticleAsync()
        {
            var articles = await _service.GetNewsArticles();
            Articles.AddRange(articles);
        }
    }
}
