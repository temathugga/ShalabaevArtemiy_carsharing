using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
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

        private void btnClients_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new ClientsPage());
        }

        private void btnCars_Click(object sender, RoutedEventArgs e)
        {
            //mainFrame.Navigate(new CarsPage());
            //txtTitle.Text = "Автомобили";
        }

        private void btnTariffs_Click(object sender, RoutedEventArgs e)
        {
            //mainFrame.Navigate(new TariffsPage());
            //txtTitle.Text = "Тарифы";
        }

        private void btnServices_Click(object sender, RoutedEventArgs e)
        {
            //mainFrame.Navigate(new ServicesPage());
            //txtTitle.Text = "Услуги";
        }
        private void btnOrders_Click(object sender, RoutedEventArgs e)
        {
            //mainFrame.Navigate(new OrdersPage());
            //txtTitle.Text = "Заказы";
        }

        private void btnReports_Click(object sender, RoutedEventArgs e)
        {
            //mainFrame.Navigate(new WorkReportsPage());
            //txtTitle.Text = "Отчеты о работах";
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}
