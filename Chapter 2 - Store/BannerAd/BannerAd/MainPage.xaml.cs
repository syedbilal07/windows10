using Microsoft.Advertising.WinRT.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BannerAd
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        InterstitialAd videoAd = new InterstitialAd();
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void showAd_Click(object sender, RoutedEventArgs e)
        {
            var MyAppId = "d25517cb-12d4-4699-8bdc-52040c712cab";
            var MyAdUnitId = "11388823";
            videoAd.AdReady += videoAd_AdReady;
            videoAd.RequestAd(AdType.Video, MyAppId, MyAdUnitId);
        }
        void videoAd_AdReady(object sender, object e)
        {
            if ((InterstitialAdState.Ready) == (videoAd.State))
            {
                videoAd.Show();
            }
        }
    }
}
