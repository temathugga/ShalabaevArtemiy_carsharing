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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        private static List<Client> _clients = new List<Client>();

        private static int _nextId = 1;


        public ClientsPage()
        {
            InitializeComponent();
            Loaded += (s, e) => LoadData();
        }


        private void LoadData()
        {
            dgClients.ItemsSource = null;         
            dgClients.ItemsSource = _clients;     
        }


        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            ClientEditWindow window = new ClientEditWindow();
            if (window.ShowDialog() == true)
            {
                Client newClient = window.Client;
                newClient.Id = _nextId++;                    
                newClient.ExternalId = _nextId.ToString("D9"); 
                _clients.Add(newClient);                     
                LoadData();                                  
            }
        }


        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Client selected = dgClients.SelectedItem as Client;
            if (selected == null)
            {
                MessageBox.Show("Выберите клиента для редактирования!");
                return;
            }

            ClientEditWindow window = new ClientEditWindow(selected);
            if (window.ShowDialog() == true)
            {
                Client updatedClient = window.Client;

                var existing = _clients.FirstOrDefault(c => c.Id == updatedClient.Id);
                if (existing != null)
                {
                    existing.Name = updatedClient.Name;
                    existing.Inn = updatedClient.Inn;
                    existing.Address = updatedClient.Address;
                    existing.Phone = updatedClient.Phone;
                    existing.IsSalesman = updatedClient.IsSalesman;
                    existing.IsBuyer = updatedClient.IsBuyer;
                }

                LoadData();
            }
        }


        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Client selected = dgClients.SelectedItem as Client;
            if (selected == null)
            {
                MessageBox.Show("Выберите клиента для удаления!");
                return;
            }

            var result = MessageBox.Show(
                $"Удалить клиента «{selected.Name}»?",
                "Подтверждение",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                _clients.Remove(selected); 
                LoadData();                
            }
        }
    }
}
