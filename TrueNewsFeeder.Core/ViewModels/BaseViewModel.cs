using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace TrueNewsFeeder.Core.ViewModels
{
    public class BaseViewModel: MvxViewModel
    {
        private string _title;
        protected IMvxNavigationService _navigationService;
        
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public BaseViewModel(IMvxNavigationService mvxNavigationService)
        {
            _navigationService = mvxNavigationService;
        }
    }
}
