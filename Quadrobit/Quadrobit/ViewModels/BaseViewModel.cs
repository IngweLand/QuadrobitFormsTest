#region Author

// Author ILYA GOLOVACH (aka IngweLand)
// http://ingweland.com
// ingweland@gmail.com
// Created: 07 03 2019

#endregion

#region

using Prism.Mvvm;
using Prism.Navigation;
using Quadrobit.Abstractions;

#endregion

namespace Quadrobit.ViewModels
{
    public class BaseViewModel : BindableBase
    {
        public BaseViewModel(IApiService apiService, INavigationService navigationService)
        {
            ApiService = apiService;
            NavigationService = navigationService;
        }

        protected IApiService ApiService { get; }
        protected INavigationService NavigationService { get; }
    }
}