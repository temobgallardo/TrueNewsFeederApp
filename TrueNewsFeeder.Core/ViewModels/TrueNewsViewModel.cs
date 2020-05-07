using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueNewsFeeder.Models.NewsApi;
using TrueNewsFeeder.Repositories.Services;

namespace TrueNewsFeeder.Core.ViewModels
{
    public class TrueNewsViewModel : BaseViewModel
    {
        private IService service;
        private News _news;
        
        public MvxObservableCollection<Article> Articles { get; private set; }
        public MvxObservableCollection<Article> CachedArticles { get; private set; }
        public IMvxCommand<String> FilterNewsCommandAsync;
        public IMvxAsyncCommand GetNewsCommandAsync;
        public News NewsBinded
        {
            get => _news;
            set => SetProperty(ref _news, value);
        }

        public TrueNewsViewModel(IMvxNavigationService mvxNavigationService, IService serviceApi) : base(mvxNavigationService)
        {
            Title = "True News Feed";
            service = serviceApi;
            Articles = new MvxObservableCollection<Article>();
            CachedArticles = new MvxObservableCollection<Article>();
            GetNewsCommandAsync = new MvxAsyncCommand(GetNewsAsync);
            FilterNewsCommandAsync = new MvxCommand<string>(FilterNewsByName);
        }

        private void FilterNewsByName(string word)
        {
            // CachedArticles was initialized in ViewAppearing()
            if (string.IsNullOrEmpty(word))
            {
                Articles.Clear();
                Articles.AddRange(CachedArticles);
            }
            else
            {
                Articles.Clear();
                Articles.AddRange(CachedArticles.Where(article => article.Title.Contains(word)));
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
            _news = await service.GetData<News>();

            if (_news == null)
            {
                return default;
            }

            return _news.Articles;
        }

        // Todo: Try to do more Functional Programming here
        private async Task GetNewsAsync()
        {
            _news = await service.GetData<News>();
            Articles.AddRange(_news.Articles);
        }
    }
}
