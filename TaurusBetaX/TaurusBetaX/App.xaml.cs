using System.Collections.Generic;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TaurusBetaX
{
    public partial class App : Application
    {
        public static string DatabaseLocation = string.Empty;
        public static string CsvLocation = string.Empty;
         
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage (new MainPage());
        }

        public App(string databaseLocation, string csvlocation)
        {
            InitializeComponent();

            DatabaseLocation = databaseLocation;
            CsvLocation = csvlocation;

           MainPage = new MainPage();
           //MainPage = new NavigationPage(new MainPage());

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
