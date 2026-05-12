using System;
using WpfApp1.Model;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for ClientEditWindow.xaml
    /// </summary>
    public partial class ClientEditWindow : Window
    {
        public Client Client { get; private set; }


        public ClientEditWindow()
        {
            InitializeComponent();
            Client = null; 
            this.Title = "Добавление клиента";
        }


        public ClientEditWindow(Client client)
        {
            InitializeComponent();
            Client = client; 
            this.Title = "Редактирование клиента";

            txtName.Text = client.Name;
            txtInn.Text = client.Inn;
            txtAddress.Text = client.Address;
            txtPhone.Text = client.Phone;
            chkSalesman.IsChecked = client.IsSalesman;
            chkBuyer.IsChecked = client.IsBuyer;
        }


        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите наименование!");
                return;
            }

            if (Client == null)
            {
                Client = new Client();
            }

            Client.Name = txtName.Text.Trim();
            Client.Inn = txtInn.Text.Trim();
            Client.Address = txtAddress.Text.Trim();
            Client.Phone = txtPhone.Text.Trim();
            Client.IsSalesman = chkSalesman.IsChecked ?? false; 
            Client.IsBuyer = chkBuyer.IsChecked ?? false;

            this.DialogResult = true;
            this.Close();
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
