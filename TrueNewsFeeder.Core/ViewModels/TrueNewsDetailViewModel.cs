using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Threading.Tasks;
using TrueNewsFeeder.Models.NewsApi;
using TrueNewsFeeder.Shared;

namespace TrueNewsFeeder.Core.ViewModels
{
    public class TrueNewsDetailViewModel : BaseViewModel, IMvxViewModel<Article>
    {
        private Article _article;
        private string _sources;
        private string _publishedAt;

        public Article Article
        {
            get => _article;
            set => SetProperty(ref _article, value);
        }
        public string Source
        {
            get => _sources;
            set => SetProperty(ref _sources, value);
        }
        public string PublishedAt
        {
            get => _publishedAt;
            set => SetProperty(ref _publishedAt, value);
        }

        public TrueNewsDetailViewModel(IMvxNavigationService navigationService) : base(navigationService)
        {
            GoBackCommand = new MvxAsyncCommand(LeapToTrueNewsViewModel);
        }

        private async Task LeapToTrueNewsViewModel()
        {
            await _navigationService.Close(this);
        }

        public void Prepare(Article article)
        {
            _article = article;
            _publishedAt = article.PublishedAt.ToString("MMM dd, yyyy hh:mm tt");
            var cleanSource = article.Source.Name.Replace("Sources", string.Empty).Replace(Environment.NewLine, string.Empty);
            var citation = string.Format(AppSettingsManager.Settings["ApaCitationPlaceHolder"]
                , article.Author
                , article.PublishedAt.ToString("yyyy, MMMM dd")
                , article.Title
                , cleanSource
                , article.Url);
            _sources = @"Sources: " + Environment.NewLine;
            _sources += citation;


        }
    }
}
