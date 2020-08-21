using System.Collections.Generic;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.Identity.Client;


[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TaurusBetaX
{
    public partial class App : Application
    {
        public static string DatabaseLocation = string.Empty;
        public static string CsvLocation = string.Empty;

        //-------------b2c--------------------------
        public static IPublicClientApplication AuthenticationClient { get; private set; }

        public static object UIParent { get; set; } = null;
        //------------------------------------------------------------------

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage (new MainPage());

            //--------------b2c----------------------------
            //AuthenticationClient = PublicClientApplicationBuilder.Create(Constants.ClientId)
            //   .WithIosKeychainSecurityGroup(Constants.IosKeychainSecurityGroups)
            //   .WithB2CAuthority(Constants.AuthoritySignin)
            //   .WithRedirectUri($"msal{Constants.ClientId}://auth")
            //   .Build();

            //MainPage = new NavigationPage(new LoginPage());
            //------------------------------------------------
        }

        public App(string databaseLocation, string csvlocation)
        {


            InitializeComponent();

            DatabaseLocation = databaseLocation;
            CsvLocation = csvlocation;


            //MainPage = new MainPage();
            //MainPage = new NavigationPage(new MainPage());

            MainPage = new NavigationPage(new SplashPage());

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
    }
}
