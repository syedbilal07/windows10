using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ProgressiveRendering
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            DataContext = Employee.GetEmployees();
        }
    }
    public class Employee : INotifyPropertyChanged
    {
        private string name;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                RaiseProperChanged();
            }
        }
        private string title;

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                RaiseProperChanged();
            }
        }
        public static Employee GetEmployee()
        {
            var emp = new Employee
            {
                Name = "Syed Bilal",
                title = "C# Programmer"
            };
            return emp;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaiseProperChanged(
            [CallerMemberName] string caller = "")
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }
        public static ObservableCollection<Employee> GetEmployees()
        {
            var employees = new ObservableCollection<Employee>();

            employees.Add(new Employee() { Name = "Ali", Title = "Developer" });
            employees.Add(new Employee() { Name = "Ammar", Title = "Programmer" });
            employees.Add(new Employee() { Name = "Talha", Title = "Designer" });
            employees.Add(new Employee() { Name = "Bilal", Title = "Programmer" });
            employees.Add(new Employee() { Name = "Hasan", Title = "Engineer" });
            employees.Add(new Employee() { Name = "Huzaifa", Title = "Manager" });

            return employees;
        }
    }
}
