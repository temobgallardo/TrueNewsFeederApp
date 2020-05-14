﻿using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
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
        private IUniversalNewsService service;
        private News _news;

        public MvxObservableCollection<Article> Articles { get; private set; }
        public MvxObservableCollection<Article> CachedArticles { get; private set; }
        public IMvxCommand<string> FilterNewsCommandAsync;

        public IMvxAsyncCommand GetNewsCommandAsync { get; private set; }
        public News NewsBinded
        {
            get => _news;
            set => SetProperty(ref _news, value);
        }

        public TrueNewsViewModel(IMvxNavigationService mvxNavigationService, IUniversalNewsService serviceApi) : base(mvxNavigationService)
        {
            Title = "True News Feed";
            service = serviceApi;
            Articles = new MvxObservableCollection<Article>();
            CachedArticles = new MvxObservableCollection<Article>();
            GetNewsCommandAsync = new MvxAsyncCommand(GetNewsArticleAsync);
            FilterNewsCommandAsync = new MvxCommand<string>(FilterNewsByTitle);
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
            var articles = await service.GetNewsArticle(request);

            if (articles == null)
            {
                return default;
            }

            return articles;
        }

        // Todo: Try to do more Functional Programming here
        private async Task GetNewsArticleAsync()
        {
            var articles = await service.GetNewsArticle();
            Articles.AddRange(articles);
        }
    }
}
