using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

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
    }
}
