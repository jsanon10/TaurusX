﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaurusBetaX.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaurusBetaX
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            _activityIndicator.BindingContext = this;
            if (Device.RuntimePlatform == Device.Android)
            {
                _activityIndicator.Scale = 0.2;
            }
            else if (Device.RuntimePlatform == Device.iOS)
            {
                _activityIndicator.Scale = 2;
            }
        }

        private async void OnLogInButtonClicked(object sender, EventArgs e)
        {
            var loginProvider = DependencyService.Get<ILoginProvider>();
            IsBusy = true;
            var authInfo = await loginProvider.LoginAsync();
            IsBusy = false;

            if (string.IsNullOrWhiteSpace(authInfo.AccessToken) || !authInfo.IsAuthorized)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await DisplayAlert("Error", "The app can't authenticate you", "OK");
                });
            }
            else
            {
                //TODO: Save the access and refresh tokens somewhere secure

                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadJwtToken(authInfo.IdToken);
                var claims = jsonToken?.Payload?.Claims;

                var name = claims?.FirstOrDefault(x => x.Type == "name")?.Value;
                var email = claims?.FirstOrDefault(x => x.Type == "email")?.Value;
                var preferredUsername = claims?
                    .FirstOrDefault(x => x.Type == "preferred_username")?.Value;

                Device.BeginInvokeOnMainThread(async () =>
                {
                    //await Navigation.PushAsync(new AuthInfoPage(name, email, preferredUsername));
                    await Navigation.PushAsync(new MainPage());

                });
            }
        }

    }
}