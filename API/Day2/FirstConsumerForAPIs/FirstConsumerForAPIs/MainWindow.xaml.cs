using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FirstConsumerForAPIs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            // get data from API provider "URL"
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("http://localhost:14153/api/MyBind");

            if (response.IsSuccessStatusCode)
            {
                string msg = await response.Content.ReadAsStringAsync();
                
                List<Employee> EmployeeList =
                    JsonSerializer.Deserialize<List<Employee>>(msg)??new List<Employee>();
                Employees.ItemsSource = EmployeeList;
            }
            else
            {
                MessageBox.Show("error.somthing went wrong");
            }
        }

        private void Employees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
