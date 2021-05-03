using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Foundation;
using UIKit;
//using Plugin.MediaManager.Forms.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UserNotifications;
using MediaManager;
using MediaManager.Forms.Platforms.iOS;


namespace TaurusBetaX.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {

        // The authorization flow session which receives the return URL from SFSafariViewController.
        //public IAuthorizationFlowSession CurrentAuthorizationFlow { get; set; }

        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            //Tabbed page

            //Keep screen ON
            UIApplication.SharedApplication.IdleTimerDisabled = true;
            //-----------------------------------------------------------


            //---------------------notification--------------------------------------------------------
            if (UIDevice.CurrentDevice.CheckSystemVersion(10, 0))
            {
                // Ask the user for permission to get notifications on iOS 10.0+
                UNUserNotificationCenter.Current.RequestAuthorization(
                    UNAuthorizationOptions.Alert | UNAuthorizationOptions.Badge | UNAuthorizationOptions.Sound,
                    (approved, error) => { });

                // Watch for notifications while app is active
                UNUserNotificationCenter.Current.Delegate = new UserNotificationCenterDelegate();
            }
            else if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                // Ask the user for permission to get notifications on iOS 8.0+
                var settings = UIUserNotificationSettings.GetSettingsForTypes(
                    UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound,
                    new NSSet());

                UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);
            }


            //_________________________________________________________________________________________



            //VideoViewRenderer.Init();
            CrossMediaManager.Current.Init();
            string dbName = "workout_db.sqlite";
            string csvName = "workouts1.csv";
            string folderPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "..", "Library");
            string fullpath = Path.Combine(folderPath, dbName);
            string csvpath = Path.Combine(folderPath, csvName);

            Rg.Plugins.Popup.Popup.Init();


            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App(fullpath, csvpath));

            return base.FinishedLaunching(app, options);
        }

        //public override bool OpenUrl(
        //   UIApplication application, NSUrl url,
        //   string sourceApplication, NSObject annotation)
        //{
        //    // Sends the URL to the current authorization flow (if any) which will process it if it relates to
        //    // an authorization response.
        //    if (CurrentAuthorizationFlow?.ResumeAuthorizationFlow(url) == true)
        //    {
        //        return true;
        //    }

        //    // Your additional URL handling (if any) goes here.

        //    return false;
        //}

    }
}
