using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System.Threading.Tasks;

namespace TrueNewsFeeder.Core.ViewModels
{
    public class BaseViewModel: MvxViewModel
    {
        private string _title;
        
        protected IMvxNavigationService _navigationService;

        public IMvxAsyncCommand GoBackCommand { get; protected set; }        
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public BaseViewModel(IMvxNavigationService mvxNavigationService)
        {
            _navigationService = mvxNavigationService;
            GoBackCommand = new MvxAsyncCommand(GoBackMethod);
        }

        public async Task GoBackMethod()
        {
            await _navigationService.Close(this);
        }
    }
}
