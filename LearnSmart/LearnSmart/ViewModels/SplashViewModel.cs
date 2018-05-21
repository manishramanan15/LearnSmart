﻿using LearnSmart.Services.Navigation;
using LearnSmart.ViewModels.Base;
using System.Threading.Tasks;

namespace LearnSmart.ViewModels
{
    public class SplashViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        public SplashViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override async Task InitializeAsync(object navigationData)
        {
            await _navigationService.NavigateToAsync<MainViewModel>();
        }
    }
}