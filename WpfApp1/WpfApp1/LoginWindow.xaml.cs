using System;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private bool PuzzleSolved = false;
        public LoginWindow()
        {
            InitializeComponent();
            LoadPazzle();
        }


            private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (PuzzleSolved)
            {
                MessageBox.Show("Капча не решена!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string login = txtLogin.Text;
            string password = txtPassword.Password;
         

            if (string.IsNullOrEmpty(login) && string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пожалуйста, введите логин и пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrEmpty(login))
            {
                MessageBox.Show("Пожалуйста, введите логин", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пожалуйста, введите пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (login == "admin" && password == "admin")
            {
                MessageBox.Show("Успешная авторизация", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }

        private Image firstButton;

        private void LoadPazzle()
        {
            var rnd = new Random();
            var pices = Enumerable.Range(1, 4).ToList();
            pices = pices.OrderBy(x => rnd.Next()).ToList();
            pices.ForEach(x =>
            {
                var img = new Image
                {
                    Source = new BitmapImage(new Uri($"images/{x}.png", UriKind.Relative)),
                    Tag = x,
                    Stretch = Stretch.Fill
                };
                img.MouseLeftButtonUp += Pices_Click;

                PuzzleGrid.Children.Add(img);
            });
        }

        private void CheckPuzzle()
        {
            if (PuzzleGrid.Children.OfType<Image>()
                .Select((img, i) => i + 1 == (int)img.Tag)
                .All(x => x))
            {
                MessageBox.Show("Капча решена!");
            }
        }

        private void Pices_Click(object sender, RoutedEventArgs e)
        {
            if (!(sender is Image clicked)) return;

            if (firstButton == null)
            {
                firstButton = clicked;
                firstButton.Opacity = 0.5;
                return;
            }

            if (clicked != firstButton)
            {
                (firstButton.Source, clicked.Source) = (clicked.Source, firstButton.Source);
                (firstButton.Tag, clicked.Tag) = (clicked.Tag, firstButton.Tag);
            }

            firstButton.Opacity = 1;
            firstButton = null;
            CheckPuzzle();
        }
        private void Pices_Click(object sender, MouseButtonEventArgs e)
        {
            if (sender is Image clicked) {
                if (firstButton == null)
                {
                    firstButton = clicked;
                    firstButton.Opacity = 0.5;
                    return;
                }

                if (clicked != firstButton)
                {
                    (firstButton.Source, clicked.Source) = (clicked.Source, firstButton.Source);
                    (firstButton.Tag, clicked.Tag) = (clicked.Tag, firstButton.Tag);
                }
                firstButton.Opacity = 1;
                firstButton = null;
                CheckPuzzle();
            }

        }
    }
}
