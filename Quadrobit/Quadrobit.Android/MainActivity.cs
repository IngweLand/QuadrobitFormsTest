#region Author

// Author ILYA GOLOVACH (aka IngweLand)
// http://ingweland.com
// ingweland@gmail.com
// Created: 07 03 2019

#endregion

#region

using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Prism;
using Prism.Ioc;
using Quadrobit.Abstractions;
using Quadrobit.Droid.Services;
using SegmentedControl.FormsPlugin.Android;

#endregion

namespace Quadrobit.Droid
{
    [Activity(Label = "Quadrobit", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            Xamarin.Forms.Forms.Init(this, savedInstanceState);
            SegmentedControlRenderer.Init();
            UserDialogs.Init(this);
            LoadApplication(new App(new AndroidPlatformInitializer()));
        }
    }

    class AndroidPlatformInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ISqliteConnectionService, AndroidSqliteConnectionService>();
        }
    }
}