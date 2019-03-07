#region Author

// Author ILYA GOLOVACH (aka IngweLand)
// http://ingweland.com
// ingweland@gmail.com
// Created: 07 03 2019

#endregion

#region

using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using Quadrobit.Abstractions;
using Quadrobit.Models;
using Quadrobit.Models.Constants;
using Quadrobit.Views;

#endregion

namespace Quadrobit.ViewModels
{
    public class InternalPageViewModel : BaseViewModel, INavigatedAware
    {
        private readonly IDataRepository _dataRepository;
        private ObservableCollection<DataEntry> _dataEntries;

        private bool _firstViewIsVisible = true;

        private bool _secondViewIsVisible;

        private SignInCredentials _signInCredentials;

        private bool _thirdViewIsVisible;

        public InternalPageViewModel(IApiService apiService, INavigationService navigationService,
            IDataRepository dataRepository) : base(apiService, navigationService)
        {
            _dataRepository = dataRepository;

            AddEntryCommand = new DelegateCommand(async () => await addEntry());
            RemoveEntryCommand = new DelegateCommand(async () => await removeEntry());
            LogoutCommand = new DelegateCommand(async () => await logout());
            ChangeViewCommand = new DelegateCommand<int?>(i => changeView(i));
        }


        public DelegateCommand AddEntryCommand { get; set; }

        public DelegateCommand<int?> ChangeViewCommand { get; set; }

        public ObservableCollection<DataEntry> DataEntries
        {
            get => _dataEntries;
            set => SetProperty(ref _dataEntries, value);
        }

        public bool FirstViewIsVisible
        {
            get => _firstViewIsVisible;
            set => SetProperty(ref _firstViewIsVisible, value);
        }

        public DelegateCommand LogoutCommand { get; set; }
        public DelegateCommand RemoveEntryCommand { get; set; }

        public bool SecondViewIsVisible
        {
            get => _secondViewIsVisible;
            set => SetProperty(ref _secondViewIsVisible, value);
        }

        public SignInCredentials SignInCredentials
        {
            get => _signInCredentials;
            set => SetProperty(ref _signInCredentials, value);
        }

        public bool ThirdViewIsVisible
        {
            get => _thirdViewIsVisible;
            set => SetProperty(ref _thirdViewIsVisible, value);
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.TryGetValue(NavigationParameterKey.LOGIN_CREDENTIALS, out SignInCredentials payload))
            {
                SignInCredentials = payload;
            }

            Task.Run(async () =>
            {
                DataEntries = new ObservableCollection<DataEntry>(await _dataRepository.GetAllEntries());
            });
        }

        private async Task addEntry()
        {
            var entry = new DataEntry
            {
                Title = Guid.NewGuid().ToString().Substring(0, 20),
                Subtitle = Guid.NewGuid().ToString("N").Substring(0, 12),
                Date = DateTime.Now.ToLongTimeString()
            };

            await _dataRepository.AddEntry(entry);

            DataEntries.Add(entry);
        }

        private void changeView(int? i)
        {
            if (!i.HasValue)
            {
                return;
            }

            switch (i)
            {
                case 1:
                {
                    FirstViewIsVisible = ThirdViewIsVisible = false;
                    SecondViewIsVisible = true;
                    break;
                }

                case 2:
                {
                    FirstViewIsVisible = SecondViewIsVisible = false;
                    ThirdViewIsVisible = true;
                    break;
                }

                default:
                {
                    SecondViewIsVisible = ThirdViewIsVisible = false;
                    FirstViewIsVisible = true;
                    break;
                }
            }
        }

        private async Task logout()
        {
            await NavigationService.NavigateAsync(new Uri(
                $"http://quadrobit.ingweland.com/{nameof(SignInPage)}",
                UriKind.Absolute));
        }

        private async Task removeEntry()
        {
            if (DataEntries.Count == 0)
            {
                return;
            }

            var key = DataEntries[0].Id;
            await _dataRepository.RemoveEntry(key);
            DataEntries.RemoveAt(0);
        }
    }
}