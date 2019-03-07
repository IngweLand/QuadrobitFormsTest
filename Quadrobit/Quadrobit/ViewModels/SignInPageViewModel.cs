#region Author

// Author ILYA GOLOVACH (aka IngweLand)
// http://ingweland.com
// ingweland@gmail.com
// Created: 07 03 2019

#endregion

#region

using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Prism.Commands;
using Prism.Navigation;
using Quadrobit.Abstractions;
using Quadrobit.Models;
using Quadrobit.Models.Constants;
using Quadrobit.Views;

#endregion

namespace Quadrobit.ViewModels
{
    public class SignInPageViewModel : BaseViewModel
    {
        private string _password;

        private string _username;

        public SignInPageViewModel(IApiService apiService, INavigationService navigationService) : base(apiService,
            navigationService)
        {
            SignInCommand = new DelegateCommand(async () => await signIn());
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public DelegateCommand SignInCommand { get; set; }

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        private async Task signIn()
        {
            if (!validate())
            {
                UserDialogs.Instance.Alert("All fields are mandatory", "Login error");
                return;
            }

            var signInSuccessfull = await ApiService.Login(_username, _password);
            if (signInSuccessfull)
            {
                var payload = new SignInCredentials
                {
                    Username = _username,
                    Password = _password
                };
                Username = Password = null;
                await NavigationService.NavigateAsync(new Uri(
                    $"http://quadrobit.ingweland.com/{nameof(InternalPage)}",
                    UriKind.Absolute), new NavigationParameters
                {
                    {
                        NavigationParameterKey.LOGIN_CREDENTIALS, payload
                    }
                });
            }
            else
            {
                UserDialogs.Instance.Alert("Username or password is incorrect", "Login error");
            }
        }

        private bool validate()
        {
            if (string.IsNullOrWhiteSpace(_username) || string.IsNullOrWhiteSpace(_password))
            {
                return false;
            }

            return true;
        }
    }
}