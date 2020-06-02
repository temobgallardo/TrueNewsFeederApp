using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Threading.Tasks;
using TrueNewsFeeder.Models;
using TrueNewsFeeder.Shared;

namespace TrueNewsFeeder.Core.ViewModels
{
    public class TrueNewsDetailViewModel : BaseViewModel, IMvxViewModel<UniversalNewsEntity>
    {
        private UniversalNewsEntity _article;
        private string _sources;
        private string _publishedAt;

        public UniversalNewsEntity Article
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

        public void Prepare(UniversalNewsEntity article)
        {
            _article = article;
            _publishedAt = article.PublishedAt.ToString("MMM dd, yyyy hh:mm tt");
            var cleanSource = article.Source.Replace("Sources", string.Empty).Replace(Environment.NewLine, string.Empty);
            var citation = string.Format(AppSettingsManager.Settings["ApaCitationPlaceHolder"]
                , article.Source
                , article.PublishedAt.ToString("yyyy, MMMM dd")
                , article.Title
                , cleanSource
                , article.Url);
            _sources = @"Sources: " + Environment.NewLine;
            _sources += citation;


        }
    }
}
