using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ConnectedExperience
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            SetBackgroundFromSettings();
            Windows.Storage.ApplicationData.Current.DataChanged += RoamingDataChanged;
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            Windows.Storage.ApplicationData.Current.DataChanged -= RoamingDataChanged;
        }
        private void RoamingDataChanged(Windows.Storage.ApplicationData sender, object args)
        {
            // Something has changed in the roaming data or settings 
            var ignore = Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => SetBackgroundFromSettings());
        }
        private void SetBackgroundFromSettings()
        {
            // Get the roaming settings 
            Windows.Storage.ApplicationDataContainer roamingSettings = Windows.Storage.ApplicationData.Current.RoamingSettings;

            if (roamingSettings.Values.ContainsKey("PreferBrownBgColor"))
            {
                var colorName = roamingSettings.Values["PreferBrownBgColor"].ToString();

                if (colorName == "Gray")
                {
                    MainGrid.Background = new SolidColorBrush(Colors.Gray);
                    GrayRadioButton.IsChecked = true;
                }
                else if (colorName == "Brown")
                {
                    MainGrid.Background = new SolidColorBrush(Colors.Brown);
                    BrownRadioButton.IsChecked = true;
                }
            }
        }
        private void radioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (GrayRadioButton.IsChecked.HasValue && (GrayRadioButton.IsChecked.Value == true))
            {
                Windows.Storage.ApplicationData.Current.RoamingSettings.Values["PreferBrownBgColor"] = "Gray";
            }
            else
            {
                Windows.Storage.ApplicationData.Current.RoamingSettings.Values["PreferBrownBgColor"] = "Brown";
            }
            SetBackgroundFromSettings();
        }
    }
}
