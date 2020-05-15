using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Threading.Tasks;
using TrueNewsFeeder.Models.NewsApi;

namespace TrueNewsFeeder.Core.ViewModels
{
    public class TrueNewsDetailViewModel : BaseViewModel, IMvxViewModel<Article>
    {
        private Article _article;
        private string _newsTitle;
        private string _content;
        private string _sources;

        public Article Article
        {
            get => _article;
            set => SetProperty(ref _article, value);
        }
        public string NewsTitle
        {
            get => _newsTitle;
            set => SetProperty(ref _newsTitle, value);
        }
        public string Content
        {
            get => _content;
            set => SetProperty(ref _content, value);
        }
        public string Source
        {
            get => _sources;
            set => SetProperty(ref _sources, value);
        }
        public IMvxAsyncCommand GoBackCommand { get; private set; }

        public TrueNewsDetailViewModel(IMvxNavigationService navigationService) : base(navigationService)
        {
            GoBackCommand = new MvxAsyncCommand(LeapToTrueNewsViewModel);
        }

        private async Task LeapToTrueNewsViewModel()
        {
            await _navigationService.Close(this);
        }

        public void Prepare(Article parameter)
        {
            _article = parameter;
            _newsTitle = parameter.Title;
            _content = parameter.Description + Environment.NewLine
                + parameter.Content;
            _sources = @"Sources: " + Environment.NewLine + _article.Source.Name;
            
        }
    }
}
