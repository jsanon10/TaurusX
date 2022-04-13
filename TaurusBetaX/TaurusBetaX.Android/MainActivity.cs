using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
//using TaurusBetaX.Droid.Implementations;
//using TaurusBetaX.Helpers;
using Org.Json;
using System.IO;
using MediaManager;
using Microsoft.Identity.Client;
using MediaManager.Forms;
//using Plugin.MediaManager.Forms.Android;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Plugin.LocalNotifications;

[assembly: ExportRenderer(typeof(Picker), typeof(PickerRenderer))]
namespace TaurusBetaX.Droid
{
    [Activity(Label = "Toruflex", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        internal static MainActivity Instance { get; private set; }

        protected override void OnCreate(Bundle bundle)
        {
            //Keep screen ON
            this.Window.SetFlags(WindowManagerFlags.KeepScreenOn, WindowManagerFlags.KeepScreenOn);

            Instance = this;

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            //Lottie.Forms.AnimationView.Init(); 
            CrossMediaManager.Current.Init();

            Rg.Plugins.Popup.Popup.Init(this, bundle);
            string dbName = "workout_db.sqlite";
            string csvName = "workouts1.csv";
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string fullpath = Path.Combine(folderPath, dbName);
            string csvpath = Path.Combine(folderPath, csvName);

            //--------------Notification-------------------

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            //---------------------------------------------


            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App(fullpath, csvpath));

            LocalNotificationsImplementation.NotificationIconId = Resource.Drawable.transparent_favicon;
        }
    }
}