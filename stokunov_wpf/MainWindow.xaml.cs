using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace stokunov_wpf
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string iconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "icon.ico");
            if (File.Exists(iconPath))
            {
                this.Icon = BitmapFrame.Create(new Uri(iconPath));
            }

            frmMain.Navigate(new AuthPage());
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (frmMain.CanGoBack)
                frmMain.GoBack();
        }

        private void FrmMain_ContentRendered(object sender, System.EventArgs e)
        {
            if (frmMain.CanGoBack)
                btnBack.Visibility = Visibility.Visible;
            else
                btnBack.Visibility = Visibility.Hidden;
        }
    }

    public class AuthPage : Page
    {
        public AuthPage()
        {
            Grid mainGrid = new Grid { Background = Brushes.WhiteSmoke };

            Border border = new Border
            {
                Width = 380,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Background = Brushes.White,
                BorderBrush = Brushes.SeaGreen,
                BorderThickness = new Thickness(2),
                CornerRadius = new CornerRadius(10),
                Padding = new Thickness(25)
            };

            StackPanel stack = new StackPanel { VerticalAlignment = VerticalAlignment.Center };

            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wagner-group-seeklogo.png");
            if (File.Exists(imagePath))
            {
                Image logo = new Image
                {
                    Height = 90,
                    Margin = new Thickness(0, 0, 0, 15),
                    Source = BitmapFrame.Create(new Uri(imagePath))
                };
                stack.Children.Add(logo);
            }

            stack.Children.Add(new TextBlock { Text = "Вход в систему", FontSize = 22, FontWeight = FontWeights.Bold, HorizontalAlignment = HorizontalAlignment.Center, Margin = new Thickness(0, 0, 0, 20) });
            stack.Children.Add(new TextBlock { Text = "Логин:" });
            stack.Children.Add(new TextBox { Height = 30, Margin = new Thickness(0, 0, 0, 10) });
            stack.Children.Add(new TextBlock { Text = "Пароль:" });
            stack.Children.Add(new PasswordBox { Height = 30, Margin = new Thickness(0, 0, 0, 20) });

            Button btnLogin = new Button { Content = "Войти", HorizontalAlignment = HorizontalAlignment.Stretch };
            Button btnGuest = new Button { Content = "Войти как гость", HorizontalAlignment = HorizontalAlignment.Stretch };

            btnGuest.Click += (s, e) =>
            {
                if (Application.Current.MainWindow is MainWindow mainWin)
                {
                    mainWin.frmMain.Navigate(new ClientPage());
                }
            };

            stack.Children.Add(btnLogin);
            stack.Children.Add(btnGuest);

            border.Child = stack;
            mainGrid.Children.Add(border);
            this.Content = mainGrid;
        }
    }

    public class ClientPage : Page
    {
        public ClientPage()
        {
            Grid mainGrid = new Grid { Background = Brushes.White };

            StackPanel stack = new StackPanel
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };

            stack.Children.Add(new TextBlock
            {
                Text = "Страница клиентов",
                FontSize = 28,
                FontWeight = FontWeights.Bold,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 0, 0, 10)
            });

            stack.Children.Add(new TextBlock
            {
                Text = "Вы вошли как гость.",
                FontSize = 16,
                HorizontalAlignment = HorizontalAlignment.Center
            });

            mainGrid.Children.Add(stack);
            this.Content = mainGrid;
        }
    }
}