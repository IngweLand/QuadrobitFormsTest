#region Author

// Author ILYA GOLOVACH (aka IngweLand)
// http://ingweland.com
// ingweland@gmail.com
// Created: 07 03 2019

#endregion

#region

using Foundation;
using Prism;
using Prism.Ioc;
using Quadrobit.Abstractions;
using Quadrobit.iOS.Services;
using SegmentedControl.FormsPlugin.iOS;
using UIKit;

#endregion

namespace Quadrobit.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Xamarin.Forms.Forms.Init();
            SegmentedControlRenderer.Init();
            LoadApplication(new App(new IosPlatformInitializer()));

            return base.FinishedLaunching(app, options);
        }
    }

    class IosPlatformInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ISqliteConnectionService, IosSqliteConnectionService>();
        }
    }
}