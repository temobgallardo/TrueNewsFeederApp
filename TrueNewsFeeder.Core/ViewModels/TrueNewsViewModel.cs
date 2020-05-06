using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
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

        public News NewsBinded
        {
            get => _news;
            set => SetProperty(ref _news, value);
        }

        public IMvxAsyncCommand GetNewsCommandAsync;

        public TrueNewsViewModel(IMvxNavigationService mvxNavigationService, IService serviceApi) : base(mvxNavigationService) 
        {
            service = serviceApi;
            Articles = new MvxObservableCollection<Article>();
            GetNewsCommandAsync = new MvxAsyncCommand(GetNewsAsync);
        }

        // TODO: Figure out how to override this method to async Task since async void may result in uncaught exceptions and the only way to get to them is to go to the SynchronizationContext that was active when this method or any async void was started.
        public override async void ViewAppearing()
        {
            base.ViewAppearing();
            _news = await service.GetData<News>();
            Articles.AddRange(_news.Articles);

            /*
            try
            {
                var news = await Task.FromResult(GetNewsFromServiceAsync());
                _news = news.Result;
                Articles.AddRange(_news.Articles);
            }
            catch (Exception)
            {
                throw;
            }
            */
        }

        public async Task<News> GetNewsFromServiceAsync()
        {
            return await service.GetData<News>();  
        }

        private async Task GetNewsAsync()
        {
            _news = await service.GetData<News>();
            Articles.AddRange(_news.Articles);
        }
    }
}
