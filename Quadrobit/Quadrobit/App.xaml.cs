using System;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using Quadrobit.Abstractions;
using Quadrobit.Repositories;
using Quadrobit.Services;
using Quadrobit.ViewModels;
using Quadrobit.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Quadrobit
{
    public partial class App : PrismApplication
    {
         public App(IPlatformInitializer initializer = null) : base(initializer)
        {
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

         protected override void OnInitialized()
        {
            InitializeComponent();

                NavigationService.NavigateAsync(new Uri(
                    $"http://quadrobit.ingweland.com/{nameof(SignInPage)}",
                    UriKind.Absolute));
        }

         protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IDataRepository, DataRepository>();
            containerRegistry.RegisterSingleton<IApiService, ApiService>();

            containerRegistry.RegisterForNavigation<SignInPage, SignInPageViewModel>();
            containerRegistry.RegisterForNavigation<InternalPage, InternalPageViewModel>();
        }
    }
}
