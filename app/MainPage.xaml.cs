using Microsoft.UI.Xaml.Controls;
using Microsoft.Web.WebView2.Core;
using System;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

namespace YTMusicUWP
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            currentView.BackRequested += OnBackRequested;
            this.InitializeComponent();
        }

        private void OnBackRequested(object sender, BackRequestedEventArgs e)
        {
            if (WebView2.CoreWebView2.CanGoBack)
            {
                WebView2.CoreWebView2.GoBack();
            }
        }

        private void ChangeWebViewSettings(WebView2 sender, CoreWebView2InitializedEventArgs args)
        {
            sender.CoreWebView2.Settings.IsGeneralAutofillEnabled = false;
            sender.CoreWebView2.Settings.IsPasswordAutosaveEnabled = false;
            sender.CoreWebView2.Settings.IsReputationCheckingRequired = false;
            sender.CoreWebView2.NewWindowRequested += OnNewWindowRequested;
        }

        private async void OnNewWindowRequested(CoreWebView2 sender, CoreWebView2NewWindowRequestedEventArgs args)
        {
            args.Handled = true;
            await Windows.System.Launcher.LaunchUriAsync(new Uri(args.Uri));
        }

    }
}
