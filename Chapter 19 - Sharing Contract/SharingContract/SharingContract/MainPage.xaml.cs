using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
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

namespace SharingContract
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        DataTransferManager dataTransferManager;
        public MainPage()
        {
            this.InitializeComponent();
            dataTransferManager = DataTransferManager.GetForCurrentView();
            dataTransferManager.DataRequested += dataTransferManager_DataRequested;

        }

        void dataTransferManager_DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            Uri sharedWebLink = new Uri("https://msdn.microsoft.com");
            if(sharedWebLink != null)
            {
                DataPackage dataPackage = args.Request.Data;
                dataPackage.Properties.Title = "Sharing MSDN Link";
                dataPackage.Properties.Description = "The Microsoft Developer Network (MSDN) is designed to help developers write applications using Microsoft products and technologies.";
                dataPackage.SetWebLink(sharedWebLink);
            }
        }

        private void InvokeShareContractButton_Click(object sender, RoutedEventArgs e)
        {
            DataTransferManager.ShowShareUI();
        }
    }
}
