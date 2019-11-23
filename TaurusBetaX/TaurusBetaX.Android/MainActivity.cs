using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;
using MediaManager;
using MediaManager.Forms;
//using Plugin.MediaManager.Forms.Android;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;




[assembly: ExportRenderer(typeof(Picker), typeof(PickerRenderer))]
namespace TaurusBetaX.Droid
{
    [Activity(Label = "TaurusBetaX", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
    

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            //VideoViewRenderer.Init();
            CrossMediaManager.Current.Init();

            Rg.Plugins.Popup.Popup.Init(this, bundle);
            string dbName = "workout_db.sqlite";
            string csvName = "workouts.csv";
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string fullpath = Path.Combine(folderPath, dbName);
            string csvpath = Path.Combine(folderPath, csvName);

            //--------------Notification-------------------

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            //---------------------------------------------

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App(fullpath, csvpath));
        }







        //private void PlayMethodInAndroidActivity()
        //{
        //    var videoUrl = "android.resource://" + Resources.GetResourcePackageName(Resource.Raw.VideoFile.mp4) + "/" + Resource.Raw.VideoFile;

        //    // this method in the _formsMediaManager may call to CrossMediaManager.Current.Play(videoUrl);
        //    _formsMediaManager.PlayVideo(videoUrl.AbsoluteString);

        //    // or if you want to add to a queue

        //    // this method in the _formsMediaManager may call to  CrossMediaManager.Current.MediaQueue.Add(...);
        //    _formsMediaManager.AddToVideoQueue(videoUrl);
        //}
    }
}