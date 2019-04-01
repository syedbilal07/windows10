using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Lifecycle
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
        public sealed partial class MainPage : Page
        {
            Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

        public MainPage()
            {
                this.InitializeComponent();
                Application.Current.Suspending += new SuspendingEventHandler(App_Suspending);
                Application.Current.Resuming += new EventHandler<Object>(App_Resuming);
            }

            async void App_Suspending(Object sender, Windows.ApplicationModel.SuspendingEventArgs e)
            {

                // Create a simple setting 
                localSettings.Values["FirstName"] = fName.Text;
                localSettings.Values["LastName"] = lName.Text;
                localSettings.Values["Email"] = email.Text;
            }

            private void App_Resuming(Object sender, Object e)
            {
                fName.Text = localSettings.Values["FirstName"];
                lName.Text = localSettings.Values["LastName"];
                email.Text = localSettings.Values["Email"];
            }

        }

        public abstract class BindableBase : INotifyPropertyChanged
        {
            private string _FirstName = default(string);

            public string FirstName
            {
                get { return _FirstName; }
                set { Set(ref _FirstName, value); }
            }

            private string _LastName = default(string);

            public string LastName
            {
                get { return _LastName; }
                set { Set(ref _LastName, value); }
            }

            private string _Email = default(string);

            public string Email
            {
                get { return _Email; }
                set { Set(ref _Email, value); }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            public void RaisePropertyChanged([CallerMemberName]string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            public void Set<T>(ref T storage, T value,
               [CallerMemberName()]string propertyName = null)
            {

                if (!object.Equals(storage, value))
                {
                    storage = value;
                    RaisePropertyChanged(propertyName);
                }
            }
        }
    }
